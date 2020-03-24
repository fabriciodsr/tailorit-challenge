using System.ComponentModel.DataAnnotations;

namespace TailorITChallenge.Domain.Entities
{
    public class Authentication : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
    }
}