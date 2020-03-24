using System.ComponentModel.DataAnnotations;

namespace TailorITChallenge.Application.DTO
{
    public class AuthDTO : BaseDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}