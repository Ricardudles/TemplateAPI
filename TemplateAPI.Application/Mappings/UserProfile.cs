using AutoMapper;
using Template.Application.DTOs;
using Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(prop => prop.Password, map => map.MapFrom(src => src.PasswordHash)).ReverseMap();
        }
    }
}
