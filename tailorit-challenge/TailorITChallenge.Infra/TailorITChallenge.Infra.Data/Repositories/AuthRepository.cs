using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Infra.Data.Context;

namespace TailorITChallenge.Infra.Data.Repositories
{
    public class AuthRepository : BaseRepository<Authentication>, IAuthRepository
    {
        public AuthRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
