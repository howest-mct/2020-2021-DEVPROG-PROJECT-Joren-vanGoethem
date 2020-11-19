using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Cast
    {
        public string name { get; set; }
        [JsonProperty("character_name")]
        public string characterName { get; set; }
        [JsonProperty("url_small_image")]
        public string urlSmallImage { get; set; }
        [JsonProperty("imdb_code")]
        public string imdbCode { get; set; }
    }
}
