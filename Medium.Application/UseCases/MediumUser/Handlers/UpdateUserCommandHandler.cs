using AutoMapper;
using MediatR;
using Medium.Application.Abstraction;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.UseCases.MediumUser.Handlers;

public class UpdateUserCommandHandler(IAppDbContext _appDbContext, IMapper mapper) : IRequestHandler<UpdateUserCommand, User>
{
    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

        if (user != null)
        {
            user.ModifiedDate = DateTimeOffset.UtcNow;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Bio = request.Bio;
            user.PasswordHash = request.PasswordHash;
            user.PhotoPath = request.PhotoPath;
            user.UserName = request.UserName;
            user.FollowersCount = request.FollowersCount;
            user.Login = request.Login;

            await _appDbContext.SavechangesAsync(cancellationToken);

            return user;
        }

        return null;
    }
}