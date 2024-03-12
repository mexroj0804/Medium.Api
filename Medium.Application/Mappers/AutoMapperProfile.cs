using AutoMapper;
using Medium.Domain.DTOs;
using Medium.Domain.Entities;

namespace Medium.Application.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}