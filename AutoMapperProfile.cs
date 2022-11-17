using AutoMapper;
using chat_test.DTO;
using chat_test.DTO.Users;
using chat_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_test
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<AddUserDto, User>();
        }
    }
}
