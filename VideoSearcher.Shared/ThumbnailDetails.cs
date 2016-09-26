using Newtonsoft.Json;

namespace VideoSearcher.Shared
{
    public class ThumbnailDetails 
    {
        /// <summary>The default image for this resource.</summary>
        [JsonProperty("default")]
        public Thumbnail Default { get; set; }

        /// <summary>The high quality image for this resource.</summary>
        [JsonProperty("high")]
        public Thumbnail High { get; set; }

        /// <summary>The maximum resolution quality image for this resource.</summary>
        [JsonProperty("maxres")]
        public Thumbnail Maxres { get; set; }

        /// <summary>The medium quality image for this resource.</summary>
        [JsonProperty("medium")]
        public Thumbnail Medium { get; set; }

        /// <summary>The standard quality image for this resource.</summary>
        [JsonProperty("standard")]
        public Thumbnail Standard { get; set; }
    }
}