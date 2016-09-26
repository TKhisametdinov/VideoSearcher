namespace VideoSearcher.SharedUtils.Interfaces
{
    public interface IUrlProvider
    {
        string GetBaseServiceUrl();
        string GetMovieInfosUrl(string query, int page);
    }
}
