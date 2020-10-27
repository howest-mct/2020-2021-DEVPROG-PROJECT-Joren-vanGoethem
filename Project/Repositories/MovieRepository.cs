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
        public async static Task<List<Movie>> GetMoviesAsync(int parLimit = 20, int parPage = 1, 
        string parQuality = "all", int parMinimum_rating = 0, string parQuery_term = "0", string parGenre = "all", 
        string parSort_by = "rating", string parOrder_by = "desc", bool parWith_rt_ratings = false)
        {
            List<Movie> Movies = new List<Movie>();

            //httpClient nodig --> API call uitvoeren
            using (HttpClient Client = await GetClientAsync())
            {
                string Url = $"{_APILINK}list_movies.json?limit={parLimit}&page={parPage}" +
                    $"&quality={parQuality}&minimum_rating={parMinimum_rating}&query_term={parQuery_term}" +
                    $"&genre={parGenre}&sort_by={parSort_by}&order_by={parOrder_by}&with_rt_ratings={parWith_rt_ratings}"; //Only the part after the api/v2/ and ALWAYS add ?
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
