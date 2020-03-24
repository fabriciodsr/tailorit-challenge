using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Application.Interfaces
{
    public interface IAuthServiceApp : IBaseApp<Authentication, AuthDTO>
    {
        AuthDTO Authenticate(string username, string password);
    }
}
