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
            List<Movie> Movies = new List<Movie>();

            //httpClient nodig --> API call uitvoeren
            using (HttpClient Client = await GetClientAsync())
            {
                string Url = $"{_APILINK}list_movies.json?limit={limit}&page={page}" +
                    $"&quality={quality}&minimum_rating={minimumRating}&query_term={queryTerm}" +
                    $"&genre={genre}&sort_by={sortBy}&order_by={orderBy}&with_rt_ratings={withRtRatings}"; //Only the part after the api/v2/ and ALWAYS add ?
                Debug.WriteLine(Url);
                string json = await Client.GetStringAsync(Url);
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);
                JToken allMovies = jsonObject.SelectToken("data.movies");
                Movies = allMovies.ToObject<List<Movie>>();

                //if (json == null) return null;
                //Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                //return Movies;
                return Movies;
            }
        }

        private async static Task<HttpClient> GetClientAsync()
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            return Client;
        }



    }
}
