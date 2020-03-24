using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Infra.Data.Context;

namespace TailorITChallenge.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
