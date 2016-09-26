using Newtonsoft.Json;

namespace VideoSearcher.Shared
{
    /// <summary>
    /// A thumbnail is an image representing a resource. 
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// Height of the thumbnail image.
        /// </summary>
        [JsonProperty("height")]
        public long? Height { get; set; }

        /// <summary>
        /// The thumbnail image's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Width of the thumbnail image.
        /// </summary>
        [JsonProperty("width")]
        public long? Width { get; set; }
    }
}