using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using RentalReceiptOrganizer.Data;
using RentalReceiptOrganizer.DomainService.Interface;

namespace RentalReceiptOrganizer.WebApi
{
    public class Global : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(StandardKernel kernel)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;

            kernel.Bind<IUnitOfWork>()
                .To<RentalReceiptOrganizerUnitOfWork>()
                .WithConstructorArgument("connectionString", connectionString);
        }
    }
}