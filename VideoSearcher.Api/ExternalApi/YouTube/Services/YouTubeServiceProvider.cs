using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Configuration;

namespace VideoSearcher.Api.ExternalApi.Youtube.Services
{
    /// <summary>
    /// Provides initialized YouTubeService
    /// </summary>
    public class YouTubeServiceProvider
    {
        private YouTubeService _service;

        public YouTubeService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = InitializeService();
                }
                return _service;
            }
        }

        public YouTubeService InitializeService()
        {
            return new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
                ApplicationName = GetType().ToString()
            });
        }
    }
}