using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Helpers;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Domain.Services
{
    public class AuthService : BaseService<Authentication>, IAuthService
    {
        private readonly AuthSettings _authSettings;

        public AuthService(IOptions<AuthSettings> authSettings, IAuthRepository repository)
            : base(repository)
        {
            _authSettings = authSettings.Value;
        }

        public Authentication Authenticate(string username, string password)
        {
            var user = repository.SelectAll().SingleOrDefault(x => x.Username == username);
            var passwordHash = AuthExtensionMethods.HashPassword(password, user.Salt);
            var validator = AuthExtensionMethods.VerifyHashedPassword(passwordHash[1], user.Password);

            // return null if user not found
            if (user == null || !validator)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            repository.Update(user);

            return user.WithoutPassword();
        }
    }
}