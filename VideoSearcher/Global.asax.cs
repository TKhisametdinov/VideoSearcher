using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using VideoSearcher.Windsor;

namespace VideoSearcher
{
    public class MvcApplication : HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_Start()
        {
            _container = IoC.BootstrapContainer();
            _container.Install(FromAssembly.This());

            //Set the controller builder to use our custom controller factory
            var controllerFactory = new WindsorControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _container?.Dispose();
        }
    }
}
