using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Service;
using Scozzard.Service.Interfaces;
using Autofac;
using Scozzard.XboxApiClient.Client;
using Scozzard.Respository.Repositories;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Task.SyncUser
{
   public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.Register(o => new SyncXboxUsersService(o.Resolve<XboxApi>(), o.Resolve<IXboxUserService>(), o.Resolve<IUserService>()));
            builder.RegisterType<XboxApi>();
            builder.RegisterType<XboxUserService>().As<IXboxUserService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<XboxUserRepository>().As<IXboxUserRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();

            using (var container = builder.Build())
            {
                container.Resolve<SyncXboxUsersService>().SyncXboxUsers();
            }
        }
    }
}
