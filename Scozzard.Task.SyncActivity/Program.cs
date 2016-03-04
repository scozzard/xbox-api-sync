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

            builder.RegisterType<DbFactory>().As<IDbFactory>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<XboxApi>().SingleInstance();
            builder.RegisterType<XboxUserRepository>().As<IXboxUserRepository>().SingleInstance();
            builder.RegisterType<ActivityRepository>().As<IActivityRepository>().SingleInstance();
            builder.RegisterType<XboxUserService>().As<IXboxUserService>().SingleInstance();
            builder.RegisterType<ActivityService>().As<IActivityService>().SingleInstance();

            builder.Register(o => new SyncActivityService(o.Resolve<IXboxUserService>(), o.Resolve<IActivityService>(), o.Resolve<XboxApi>())).SingleInstance();


            using (var container = builder.Build())
            {
                container.Resolve<SyncActivityService>().SyncActivity();
            }
        }
    }
}
