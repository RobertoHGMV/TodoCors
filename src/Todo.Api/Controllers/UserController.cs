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
        readonly IUserRepository _repository;
        readonly UserHandler _handler;

        public UserController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet("v1/users")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 0)]
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
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

        [HttpGet("v1/users/{username}")]
        public IActionResult Get(string username)
        {
            try
            {
                var user = _repository.GetByUserName(username);

                if (user is null)
                    return BadRequest(new GenericCommandResult(false, "Usuário não encontrado", null));

                var result = new GetUserCommandResult(user.Name.FirstName, user.Name.LastName, user.Login.UserName, user.Email.Address);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
            }
        }

        [HttpPost("v1/users")]
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

        [HttpPut("v1/users")]
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

        //[HttpDelete]
        //[Route("v1/users")]
        //public IActionResult Delete([FromBody] DeleteUserCommand command)
        //{
        //    try
        //    {
        //        var result = _handler.Handle(command) as GenericCommandResult;

        //        if (!result.Success) return BadRequest(result);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new GenericCommandResult(false, "Operação não realizada", ex));
        //    }
        //}

        [HttpDelete("v1/users")]
        public IActionResult Delete(string userName)
        {
            try
            {
                var result = _handler.Handle(new DeleteUserCommand { UserName = userName }) as GenericCommandResult;

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
