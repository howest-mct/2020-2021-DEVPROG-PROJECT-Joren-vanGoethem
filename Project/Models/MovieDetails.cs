﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class MovieDetails
    {
        public int id { get; set; }
        public string url { get; set; }

        [JsonProperty("imdb_code")]
        public string imdbCode { get; set; }
        public string title { get; set; }

        [JsonProperty("title_english")]
        public string titleEnglish { get; set; }

        [JsonProperty("title_long")]
        public string titleLong { get; set; }
        public string slug { get; set; }
        public int year { get; set; }
        public float rating { get; set; }
        public int runtime { get; set; }
        public string[] genres { get; set; }

        [JsonProperty("download_count")]
        public int downloadCount { get; set; }

        [JsonProperty("like_count")]
        public int likeCount { get; set; }

        [JsonProperty("description_intro")]
        public string descriptionIntro { get; set; }

        [JsonProperty("description_full")]
        public string descriptionFull { get; set; }

        [JsonProperty("yt_trailer_code")]
        public string ytTrailerCode { get; set; }
        public string language { get; set; }

        [JsonProperty("mpa_rating")]
        public string mpaRating { get; set; }

        [JsonProperty("background_image")]
        public string backgroundImage { get; set; }

        [JsonProperty("background_image_original")]
        public string backgroundImageOriginal { get; set; }

        [JsonProperty("small_cover_image")]
        public string smallCoverImage { get; set; }

        [JsonProperty("medium_cover_image")]
        public string mediumCoverImage { get; set; }

        [JsonProperty("large_cover_image")]
        public string largeCoverImage { get; set; }

        [JsonProperty("medium_screenshot_image1")]
        public string mediumScreenshotImage1 { get; set; }

        [JsonProperty("medium_screenshot_image2")]
        public string mediumScreenshotImage2 { get; set; }

        [JsonProperty("medium_screenshot_image3")]
        public string mediumScreenshotImage3 { get; set; }

        [JsonProperty("large_screenshot_image1")]
        public string largeScreenshotImage1 { get; set; }

        [JsonProperty("large_screenshot_image2")]
        public string largeScreenshotImage2 { get; set; }

        [JsonProperty("large_screenshot_image3")]
        public string largeScreenshotImage3 { get; set; }
        public Cast[] cast { get; set; }
        public Torrent[] torrents { get; set; }

        [JsonProperty("date_uploaded")]
        public string dateUploaded { get; set; }

        [JsonProperty("date_uploaded_unix")]
        public int dateUploadedUnix { get; set; }
        public string resolutions
        {
            get
            {
                string resolutionString = "";
                foreach (Torrent t in torrents)
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
}
