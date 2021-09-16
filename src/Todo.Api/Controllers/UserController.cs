using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Users;
using Todo.Domain.Handlers.Users;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        IUserRepository _repository;
        UserHandler _handler;

        public UserController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/[controller]")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _repository.GetAll();

                var result = new List<GetUserCommandResult>();

                foreach (var user in users)
                    result.Add(new GetUserCommandResult(user.Name.FirstName, user.Name.LastName, user.Login.UserName, user.Email.Address));

                return Ok(new GenericCommandResult(true, "Operação realizada com sucesso", result));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }

        [HttpGet]
        [Route("v1/[controller]/{username}")]
        public IActionResult Get(string username)
        {
            try
            {
                var command = new GetUserCommand(username);
                var result = _handler.Handle(command) as GenericCommandResult;

                if (!result.Success) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }

        [HttpPost]
        [Route("v1/[controller]")]
        public IActionResult Add([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = _handler.Handle(command) as GenericCommandResult;

                if (!result.Success) return BadRequest(result);

                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }

        [HttpPut]
        [Route("v1/[controller]")]
        public IActionResult Update([FromBody] UpdateUserCommand command)
        {
            try
            {
                var result = _handler.Handle(command) as GenericCommandResult;

                if (!result.Success) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }

        [HttpDelete]
        [Route("v1/[controller]")]
        public IActionResult Delete([FromBody] DeleteUserCommand command)
        {
            try
            {
                var result = _handler.Handle(command) as GenericCommandResult;

                if (!result.Success) return BadRequest(result);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }
    }
}
