using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.Interfaces;
using TailorITChallenge.Application.Services;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Domain.Interfaces.Services;
using TailorITChallenge.Domain.Services;
using TailorITChallenge.Infra.Data.Repositories;

namespace TailorITChallenge.Infra.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //Application
            svcCollection.AddScoped(typeof(IBaseApp<,>), typeof(BaseApp<,>));
            svcCollection.AddScoped<IAuthServiceApp, AuthServiceApp>();
            svcCollection.AddScoped<IUserServiceApp, UserServiceApp>();

            //Domain
            svcCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            svcCollection.AddScoped<IAuthService, AuthService>();
            svcCollection.AddScoped<IUserService, UserService>();

            //Repository
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            svcCollection.AddScoped<IAuthRepository, AuthRepository>();
            svcCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
