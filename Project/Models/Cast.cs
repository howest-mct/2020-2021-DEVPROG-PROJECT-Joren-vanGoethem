using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Cast
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("character_name")]
        public string CharacterName { get; set; }
        [JsonProperty("url_small_image")]
        public string UrlSmallImage { get; set; }
        [JsonProperty("imdb_code")]
        public string ImdbCode { get; set; }

        public string ImdbUrl {
            get {
                return $"https://www.imdb.com/name/nm{ImdbCode}/";
            }
        }
    }
}
