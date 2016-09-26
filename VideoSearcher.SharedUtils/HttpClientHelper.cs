using System.Net.Http;
using System.Threading.Tasks;
using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.SharedUtils
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public async Task<HttpResponseMessage> GetAsync(string urlWithParams)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetAsync(urlWithParams);
            }
        }
    }
}
