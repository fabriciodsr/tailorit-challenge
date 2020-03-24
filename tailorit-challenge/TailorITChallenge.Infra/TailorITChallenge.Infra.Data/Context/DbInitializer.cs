using TailorITChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorITChallenge.Domain.Helpers;

namespace TailorITChallenge.Infra.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext ctx)
        {
            if (!ctx.Authentication.Any())
            {
                SeedAuth(ctx);
            }

            if (!ctx.Gender.Any())
            {
                SeedGenders(ctx);
            }
        }

        private static void SeedGenders(ApplicationContext ctx)
        {
            String[] genders = { "Masculino", "Feminino" };
            foreach (var gender in genders)
            {
                var genderObj = ctx.Gender.FirstOrDefault(r => r.Description.Equals(gender));
                if (genderObj == null)
                {
                    genderObj = new Gender
                    {
                        Description = gender,
                        Active = true
                    };

                    ctx.Add(genderObj);
                    ctx.SaveChanges();
                }
            }
        }

        private static void SeedAuth(ApplicationContext ctx)
        {
            var hashedPassword = AuthExtensionMethods.HashPassword("test");
            var authObj = new Authentication
            {
                FirstName = "Test",
                LastName = "User",
                Username = "test",
                Password = hashedPassword[1],
                Salt = hashedPassword[0],
                Token = null,
                Active = true
            };
            ctx.Add(authObj);
            ctx.SaveChanges();
        }
    }
}
