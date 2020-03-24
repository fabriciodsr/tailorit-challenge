using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorITChallenge.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
