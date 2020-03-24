using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Domain.Interfaces.Services
{
    public interface IAuthService : IBaseService<Authentication>
    {
        Authentication Authenticate(string username, string password);
    }
}
