using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    // this class is only used to get the Details of the movie with the ID
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
    }
}
