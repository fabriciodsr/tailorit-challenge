using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TailorITChallenge.Application.DTO
{
    public abstract class BaseDTO
    {
        public virtual int Id { get; set; }
        [Display(Name = "Ativo")]
        public virtual bool Active { get; set; }
    }
}
