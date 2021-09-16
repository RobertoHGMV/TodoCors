using System;
using System.Collections.Generic;
using System.Text;
using Todo.Common.Commands;
using Todo.Common.Handlers;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Users;
using Todo.Domain.Models.Users;
using Todo.Domain.Repositories;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;

namespace Todo.Domain.Handlers.Users
{
    public class UserHandler : IHandler<CreateUserCommand>, IHandler<UpdateUserCommand>, IHandler<DeleteUserCommand>, IHandler<GetUserCommand>
    {
        private readonly IUow _uow;
        private readonly IUserRepository _repository;

        public UserHandler(IUow uow, IUserRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();

            if (command.HasNotifications)
                return new GenericCommandResult(false, "Não foi possível adicionar usuário", command.Notifications);

            var userTemp = _repository.GetByUserName(command.UserName);
            
            if (userTemp != null)
                return new GenericCommandResult(false, $"Existe usuário cadastrado com o nome de usuário {command.UserName}", null);

            var name = new Name(command.FirstName, command.LastName);
            var login = new Login(command.UserName, command.Password, command.ConfirmPassword);
            var email = new Email(command.Email);
            var user = new User(name, login, email);

            _repository.Add(user);
            _uow.Commit();

            return new GenericCommandResult(true, "Usuário adicionado", CreateUserCommandResult(user));
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            command.Validate();

            if (command.HasNotifications)
                return new GenericCommandResult(false, "Não foi possível atualizar usuário", command.Notifications);

            var user = _repository.GetByUserName(command.UserName);

            if (user is null)
                return new GenericCommandResult(false, "Usuário não encontrado", command.Notifications);

            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            user.Update(name, email);
            
            _repository.Update(user);
            _uow.Commit();

            return new GenericCommandResult(true, "Usuário atualizado", CreateUserCommandResult(user));
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            command.Validate();

            if (command.HasNotifications)
                return new GenericCommandResult(false, "Não foi possível completar operação", command.Notifications);

            var user = _repository.GetByUserName(command.UserName);

            if (user is null)
                return new GenericCommandResult(false, "Usuário não encontrado", command.Notifications);

            _repository.Remove(user);
            _uow.Commit();

            return new GenericCommandResult(true, "Operação realizada com sucesso!", null);
        }

        public ICommandResult Handle(GetUserCommand command)
        {
            command.Validate();

            if (command.HasNotifications)
                return new GenericCommandResult(false, "Não foi possível completar operação", command.Notifications);

            var user = _repository.GetByUserName(command.UserName);

            if (user is null)
                return new GenericCommandResult(false, "Usuário não encontrado", command.Notifications);

            return new GenericCommandResult(true, "Operação realizada com sucesso!", CreateUserCommandResult(user));
        }

        private GetUserCommandResult CreateUserCommandResult(User user)
        {
            return new GetUserCommandResult(user.Name.FirstName, user.Name.LastName, user.Login.UserName, user.Email.Address);
        }
    }
}
