using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    class MovieRepository
    {

        private const string _APILINK = "https://yts.mx/api/v2/";
       

        // List<Movie>
        public async static Task<List<Movie>> GetMoviesAsync(int limit = 10, int page = 1, 
        string quality = "all", int minimumRating = 0, string queryTerm = "0", string genre = "all", 
        string sortBy = "rating", string orderBy = "desc", bool withRtRatings = false)
        {
            List<Movie> movies = new List<Movie>();

            //httpClient nodig --> API call uitvoeren
            using (HttpClient Client = await GetClientAsync())
            {
                string url = $"{_APILINK}list_movies.json?limit={limit}&page={page}" +
                    $"&quality={quality}&minimum_rating={minimumRating}&query_term={queryTerm}" +
                    $"&genre={genre}&sort_by={sortBy}&order_by={orderBy}&with_rt_ratings={withRtRatings}"; //Only the part after the api/v2/ and ALWAYS add ?
                Debug.WriteLine(url);
                
                string json = await Client.GetStringAsync(url);
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);
                JToken allMovies = jsonObject.SelectToken("data.movies");
                movies = allMovies.ToObject<List<Movie>>();

                return movies;
            }
        }

        private async static Task<HttpClient> GetClientAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }



    }
}
