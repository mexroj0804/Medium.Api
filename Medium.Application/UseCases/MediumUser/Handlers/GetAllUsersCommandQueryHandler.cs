using MediatR;
using Medium.Application.Abstraction;
using Medium.Application.UseCases.MediumUser.Queries;
using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.UseCases.MediumUser.Handlers;

public class GetAllUsersCommandQueryHandler : IRequestHandler<GetAllUsersCommandQuery, List<User>>
{
    private readonly IAppDbContext _appDbContext;

    public GetAllUsersCommandQueryHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<User>> Handle(GetAllUsersCommandQuery request, CancellationToken cancellationToken)
    {
        var users = await _appDbContext.Users.ToListAsync();

        return users;
    }
}