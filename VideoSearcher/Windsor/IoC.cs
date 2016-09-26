using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using VideoSearcher.Interfaces;
using VideoSearcher.Providers;
using VideoSearcher.Services;
using VideoSearcher.SharedUtils;
using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Windsor
{
    public class IoC
    {
        public static IWindsorContainer BootstrapContainer()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ISearchService>().ImplementedBy<SearchService>());
            container.Register(Component.For<IHttpClientHelper>().ImplementedBy<HttpClientHelper>());
            container.Register(Component.For<IUrlProvider>().ImplementedBy<MovieInfoServiceUrlProvider>()
                 .DependsOn(Dependency.OnValue("baseUrl", ConfigurationManager.AppSettings["VideoSearcherApi"]))
            );
            
            container.Install(FromAssembly.This());

            return container;
        }
    }
}
