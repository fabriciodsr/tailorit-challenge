using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Domain.Services
{
    public class GenderService : BaseService<Gender>, IGenderService
    {
        public GenderService(IGenderRepository repository)
            : base(repository)
        {

        }
    }
}
