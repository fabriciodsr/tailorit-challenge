using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Application.Interfaces;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Application.Services
{
    public class GenderServiceApp : BaseApp<Gender, GenderDTO>, IGenderServiceApp
    {
        public GenderServiceApp(IMapper iMapper, IGenderService service)
            : base(iMapper, service)
        {
        }
    }
}
