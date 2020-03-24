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
    public class AuthServiceApp : BaseApp<Authentication, AuthDTO>, IAuthServiceApp
    {
        private readonly IAuthService _service;
        public AuthServiceApp(IMapper iMapper, IAuthService service)
            : base(iMapper, service)
        {
            _service = service;
        }

        public AuthDTO Authenticate(string username, string password)
        {
            return iMapper.Map<AuthDTO>(_service.Authenticate(username, password));
        }
    }
}
