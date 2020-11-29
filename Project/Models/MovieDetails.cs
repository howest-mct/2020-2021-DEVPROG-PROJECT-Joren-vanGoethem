using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace Project.Models
{
    public class MovieDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("imdb_code")]
        public string ImdbCode { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_english")]
        public string TitleEnglish { get; set; }

        [JsonProperty("title_long")]
        public string TitleLong { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("rating")]
        public float Rating { get; set; }
        [JsonProperty("runtime")]
        public int Runtime { get; set; }
        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        [JsonProperty("description_intro")]
        public string DescriptionIntro { get; set; }

        [JsonProperty("description_full")]
        public string DescriptionFull { get; set; }

        [JsonProperty("yt_trailer_code")]
        public string YtTrailerCode { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("mpa_rating")]
        public string MpaRating { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImage { get; set; }

        [JsonProperty("background_image_original")]
        public string BackgroundImageOriginal { get; set; }

        [JsonProperty("small_cover_image")]
        public string SmallCoverImage { get; set; }

        [JsonProperty("medium_cover_image")]
        public string MediumCoverImage { get; set; }

        [JsonProperty("large_cover_image")]
        public string LargeCoverImage { get; set; }
       
        [JsonProperty("medium_screenshot_image1")]
        public string MediumScreenshotImage1 { get; set; }

        [JsonProperty("medium_screenshot_image2")]
        public string MediumScreenshotImage2 { get; set; }

        [JsonProperty("medium_screenshot_image3")]
        public string MediumScreenshotImage3 { get; set; }

        [JsonProperty("large_screenshot_image1")]
        public string LargeScreenshotImage1 { get; set; }

        [JsonProperty("large_screenshot_image2")]
        public string LargeScreenshotImage2 { get; set; }

        [JsonProperty("large_screenshot_image3")]
        public string LargeScreenshotImage3 { get; set; }
        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }
        [JsonProperty("torrents")]
        public Torrent[] Torrents { get; set; }

        [JsonProperty("date_uploaded")]
        public string DateUploaded { get; set; }

        [JsonProperty("date_uploaded_unix")]
        public int DateUploadedUnix { get; set; }
        public string Resolutions
        {
            get
            {
                string ResolutionString = "";
                foreach (Torrent T in Torrents)
                {
                    ResolutionString += T.Quality + ", ";
                }
                ResolutionString = ResolutionString.TrimEnd(' ', ',');


                return ResolutionString;

            }
        }
        public string GenreString
        {
            get
            {
                string GenreString = "";
                foreach (string S in Genres)
                {
                    GenreString += S + " / ";
                }
                GenreString = GenreString.TrimEnd(' ', '/');

                return GenreString;

            }
        }

        public string RuntimeString
        {
            get
            {
                if (Runtime > 60)
                {
                    int Hours = Runtime / 60;
                    int Minutes = Runtime - (Hours * 60);
                    string Result = $"{Hours}h {Minutes}m";
                    return Result;
                }
                else
                {
                    return $"{Convert.ToString(Runtime)}m";
                }
            }
        }
    }
}
