using MediatR;
using Medium.Application.Abstraction;
using Medium.Application.UseCases.MediumUser.Commands;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.UseCases.MediumUser.Handlers;

public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
{
    private readonly IAppDbContext _appDbContext;

    public DeleteUserCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

        if (user == null)
            throw new Exception($"Id: {request.Id} User not found");

        _appDbContext.Users.Remove(user);

        await _appDbContext.SavechangesAsync(cancellationToken);
    }
}