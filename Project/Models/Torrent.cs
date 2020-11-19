using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Torrent
    {
        public string url { get; set; }
        public string hash { get; set; }
        public string quality { get; set; }
        public string type { get; set; }
        public int seeds { get; set; }
        public int peers { get; set; }
        public string size { get; set; }
        [JsonProperty("size_bytes")]
        public long sizeBytes { get; set; }

        [JsonProperty("date_uploaded")]
        public string dateUploaded { get; set; }

        [JsonProperty("date_uploaded_unix")]
        public int dateUploadedUnix { get; set; }
    }
}
