using Castle.Windsor;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using System.Web.Optimization;
using VideoSearcher.Api.Log;
using VideoSearcher.Api.Windsor;

namespace VideoSearcher.Api
{
    public class WebApiApplication : HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_Start()
        {
            _container = IoC.BootstrapContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(_container.Kernel);
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
        }

        protected void Application_End()
        {
            _container?.Dispose();
        }
    }
}
