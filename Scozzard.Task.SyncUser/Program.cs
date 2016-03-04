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

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<DbFactory>().As<IDbFactory>().SingleInstance();
            builder.RegisterType<XboxApi>().SingleInstance();
            builder.RegisterType<XboxUserRepository>().As<IXboxUserRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<XboxUserService>().As<IXboxUserService>().SingleInstance();
            builder.RegisterType<SyncXboxUsersService>().As<ISyncXboxUsersService>().SingleInstance();

            builder.Register(o => new SyncXboxUsersService(o.Resolve<XboxApi>(), o.Resolve<IXboxUserService>(), o.Resolve<IUserService>())).SingleInstance();

            using (var container = builder.Build())
            {
                container.Resolve<ISyncXboxUsersService>().SyncXboxUsers();
            }
        }
    }
}
