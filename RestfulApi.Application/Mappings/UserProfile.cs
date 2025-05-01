using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestfulApi.Application.DTOs;

namespace RestfulApi.Application.Mappings
{
    public class UserProfile : Profile
    {
       public UserProfile() 
       {
            CreateMap<UserProfile, UserDto>().ReverseMap();
       }
    }
}
