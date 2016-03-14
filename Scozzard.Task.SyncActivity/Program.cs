using Scozzard.Service;
using Scozzard.Service.Interfaces;
using Autofac;
using Scozzard.XboxApiClient.Client;
using Scozzard.Respository.Repositories;
using Scozzard.Respository.Infrastructure;
using Scozzard.Service.SyncServices;
using Scozzard.Service.SyncServices.Interfaces;
using AutoMapper;

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
            builder.RegisterType<GameClipRepository>().As<IGameClipRepository>().SingleInstance();
            builder.RegisterType<ScreenshotRepository>().As<IScreenshotRepository>().SingleInstance();
            builder.RegisterType<XboxUserService>().As<IXboxUserService>().SingleInstance();
            builder.RegisterType<ActivityService>().As<IActivityService>().SingleInstance();
            builder.RegisterType<GameClipService>().As<IGameClipService>().SingleInstance();
            builder.RegisterType<ScreenshotService>().As<IScreenshotService>().SingleInstance();
            builder.RegisterType<SyncActivityService>().As<ISyncActivityService>().SingleInstance();
            builder.RegisterType<SyncGameClipsService>().As<ISyncGameClipsService>().SingleInstance();

            builder.Register(o => new SyncActivityService(o.Resolve<IXboxUserService>(), o.Resolve<IActivityService>(), o.Resolve<XboxApi>())).SingleInstance();
            builder.Register(o => new SyncGameClipsService(o.Resolve<IXboxUserService>(), o.Resolve<IGameClipService>(), o.Resolve<XboxApi>())).SingleInstance();
            builder.Register(o => new SyncScreenshotsService(o.Resolve<IXboxUserService>(), o.Resolve<IScreenshotService>(), o.Resolve<XboxApi>())).SingleInstance();


            using (var container = builder.Build())
            {
                container.Resolve<SyncActivityService>().SyncActivity();
                container.Resolve<SyncGameClipsService>().SyncGameClips();
                container.Resolve<SyncScreenshotsService>().SyncScreenshots();
            }
        }
    }
}
