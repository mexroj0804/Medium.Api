using AutoMapper;
using MediatR;
using Medium.Application.Abstraction;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Domain.Entities;

namespace Medium.Application.UseCases.MediumUser.Handlers;

public class CreateUserCommandHandler : AsyncRequestHandler<CreatedCommandUser>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    protected async override Task Handle(CreatedCommandUser request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SavechangesAsync(cancellationToken);
    }
}