using System.Net.Http;
using System.Threading.Tasks;

namespace VideoSearcher.SharedUtils.Interfaces
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> GetAsync(string urlWithParams);
    }
}
