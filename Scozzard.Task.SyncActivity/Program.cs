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

namespace Scozzard.Task.SyncActivity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.Register(o => new SyncActivityService(o.Resolve<IXboxUserService>(), o.Resolve<IActivityService>(), o.Resolve<XboxApi>()));
            builder.RegisterType<XboxApi>();
            builder.RegisterType<XboxUserService>().As<IXboxUserService>();
            builder.RegisterType<XboxUserRepository>().As<IXboxUserRepository>();
            builder.RegisterType<ActivityService>().As<IActivityService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();

            using (var container = builder.Build())
            {
                container.Resolve<SyncActivityService>().SyncActivity();
            }
        }
    }
}
