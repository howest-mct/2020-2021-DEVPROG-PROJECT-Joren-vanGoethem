using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string url { get; set; }
        public string imdb_code { get; set; }
        public string title { get; set; }
        public string title_english { get; set; }
        public string title_long { get; set; }
        public string slug { get; set; }
        public int year { get; set; }
        public float rating { get; set; }
        public int runtime { get; set; }
        public string[] genres { get; set; }
        public string summary { get; set; }
        public string description_full { get; set; }
        public string synopsis { get; set; }
        public string yt_trailer_code { get; set; }
        public string language { get; set; }
        public string mpa_rating { get; set; }
        public string background_image { get; set; }
        public string background_image_original { get; set; }
        public string small_cover_image { get; set; }
        public string medium_cover_image { get; set; }
        public string large_cover_image { get; set; }
        public string state { get; set; }
        public Torrent[] torrents { get; set; }
        public string date_uploaded { get; set; }
        public int date_uploaded_unix { get; set; }

        public string resolutions
        {
            get
            {
                string resolutionString = "";
                foreach(Torrent t in torrents)
                {
                    resolutionString += t.quality + ", ";
                }
                resolutionString = resolutionString.TrimEnd(' ', ',');


                return resolutionString;

            }
        }
        public string genreString
        {
            get
            {
                string genreString = "";
                foreach (string s in genres)
                {
                    genreString += s + " / ";
                }
                genreString = genreString.TrimEnd(' ', '/');

                return genreString;

            }
        }

        public string runtimeString
        {
            get
            {
                if (runtime > 60)
                {
                    int hours = runtime / 60;
                    int minutes = runtime - (hours * 60);
                    string result = $"{hours}h {minutes}m";
                    return result;
                }
                else
                {
                    return $"{Convert.ToString(runtime)}m";
                }
            }
        }
    }

    public class Torrent
    {
        public string url { get; set; }
        public string hash { get; set; }
        public string quality { get; set; }
        public string type { get; set; }
        public int seeds { get; set; }
        public int peers { get; set; }
        public string size { get; set; }
        public long size_bytes { get; set; }
        public string date_uploaded { get; set; }
        public int date_uploaded_unix { get; set; }
    }

}
