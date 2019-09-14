using Autofac;
using Autofac.Integration.Mvc;
using emanetV2.Data;
using emanetV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace emanetV2.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AnimalService>().As<AnimalService>();
            builder.RegisterType<AnimalService>().As<IAnimalService>();
            builder.RegisterType<AnimalTypeService>().As<IAnimalTypeService>();
            builder.RegisterType<AnimalSizeService>().As<IAnimalSizeService>();
            builder.RegisterType<MemberService>().As<IMemberService>();
            builder.RegisterType<PublicationService>().As<IPublicationService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
