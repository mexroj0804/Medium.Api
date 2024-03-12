using MediatR;
using Medium.Application.Abstraction;
using Medium.Application.UseCases.MediumUser.Queries;
using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.UseCases.MediumUser.Handlers;

public class GetByIdUserCommandQueryHandler : IRequestHandler<GetByIdUserCommandQuery, User>
{
    private readonly IAppDbContext _appDbContext;

    public GetByIdUserCommandQueryHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> Handle(GetByIdUserCommandQuery request, CancellationToken cancellationToken)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);
        
        if (user == null)
            throw new Exception($"Id: {request.Id} User not found");

        return user;
    }
}