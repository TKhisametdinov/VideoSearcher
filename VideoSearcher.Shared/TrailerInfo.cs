using Newtonsoft.Json;

namespace VideoSearcher.Shared
{
    public class TrailerInfo
    {
        /// <summary>
        /// Trailer url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// List of trailer thumbnails
        /// </summary>
        public ThumbnailDetails Thumbnails { get; set; }

        /// <summary>
        /// A description of the search result.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The title of the search result. 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The creation date and time of the trailer video. 
        /// </summary>
        [JsonProperty("publishedAt")]
        public string PublishedAtRaw { get; set; }
    }
}