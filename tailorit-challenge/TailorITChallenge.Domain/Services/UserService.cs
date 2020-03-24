using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository)
            : base(repository)
        {

        }
    }
}
