using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Infra.Data.Context;

namespace TailorITChallenge.Infra.Data.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
