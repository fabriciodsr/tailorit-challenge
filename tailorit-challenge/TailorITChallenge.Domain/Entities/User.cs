using System.ComponentModel.DataAnnotations;

namespace TailorITChallenge.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public virtual Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string Password { get; set; }
    }
}