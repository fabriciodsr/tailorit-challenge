using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Application.Interfaces
{
    public interface IGenderServiceApp : IBaseApp<Gender, GenderDTO>
    {
    }
}
