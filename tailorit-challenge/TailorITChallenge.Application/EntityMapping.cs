using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Application
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            CreateMap<Authentication, AuthDTO>();
            CreateMap<AuthDTO, Authentication>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Gender, GenderDTO>();
            CreateMap<GenderDTO, Gender>();
        }
    }
}
