using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Application.DTO
{
    public class UserDTO : BaseDTO
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Data de Nascimento")]
        public string BirthDate { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public virtual Gender Gender { get; set; }

        [Display(Name = "Sexo")]
        public int GenderId { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
