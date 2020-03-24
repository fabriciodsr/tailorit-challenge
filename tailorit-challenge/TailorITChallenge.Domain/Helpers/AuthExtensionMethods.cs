using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Domain.Helpers
{
    public static class AuthExtensionMethods
    {
        public static IEnumerable<Authentication> WithoutPasswords(this IEnumerable<Authentication> auths) {
            return auths.Select(x => x.WithoutPassword());
        }

        public static Authentication WithoutPassword(this Authentication auth) {
            auth.Password = null;
            return auth;
        }

        public static string[] HashPassword(string password, string fixedSalt = "")
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            if (!String.IsNullOrEmpty(fixedSalt))
            {
                salt = Convert.FromBase64String(fixedSalt);
            }

            var saltBase64 = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            string[] passwordInfo = { saltBase64, hashed };

            return passwordInfo;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string userPassword)
        {
            if (hashedPassword.Equals(userPassword))
                return true;

            return false;
        }
    }
}