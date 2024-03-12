using MediatR;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Application.UseCases.MediumUser.Queries;
using Medium.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medium.Api.Controllers;

[Route("api/[controllers]")]
[ApiController]
public class UserController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreatedCommandUser command)
    {
        await _mediator.Send(command);

        return Ok("Ma'lumot yaratildi!");
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersCommandQuery());

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetByIdUserCommandQuery
        {
            Id = id
        });

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _mediator.Send(new DeleteUserCommand
        {
            Id = id
        });

        return Ok("Foydalanuvchi o'chirildi!");
    }

    [HttpPut]
    public async Task<ActionResult<User>> UpdateUser(UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}