namespace VideoSearcher.SharedUtils.Interfaces
{
    public interface IMovieInfoServiceUrlProvider : IUrlProvider
    {
        string GetMovieInfoByIdUrl(string imdbId);
    }
}
