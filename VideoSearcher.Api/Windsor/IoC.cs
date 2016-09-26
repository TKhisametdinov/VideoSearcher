using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http.Tracing;
using VideoSearcher.Api.Aggregator.Services;
using VideoSearcher.Api.ExternalApi.Imdb;
using VideoSearcher.Api.ExternalApi.Interfaces;
using VideoSearcher.Api.ExternalApi.Youtube.Services;
using VideoSearcher.Api.Log;
using VideoSearcher.SharedUtils;
using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Api.Windsor
{
    public class IoC
    {
        public static IWindsorContainer BootstrapContainer()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ITrailerSearcher>().ImplementedBy<YouTubeTrailerSearcher>());
            container.Register(Component.For<YouTubeServiceProvider>().ImplementedBy<YouTubeServiceProvider>());
            container.Register(Component.For<AggregatorService>().ImplementedBy<AggregatorService>());
            container.Register(Component.For<IMovieInfoService>().ImplementedBy<MovieInfoService>());
            container.Register(Component.For<ITraceWriter>().ImplementedBy<NLogger>());

            container.Register(Component.For<IMovieInfoServiceUrlProvider>().ImplementedBy<MovieInfoServiceUrlProvider>()
                 .DependsOn(Dependency.OnValue("baseUrl", ConfigurationManager.AppSettings["OmdbApiUrl"]))
            );
            container.Register(Component.For<IHttpClientHelper>().ImplementedBy<HttpClientHelper>());

            container.Install(FromAssembly.This());

            return container;
        }
    }
}
