using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveShow.Website
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;
        private const string apiEndpoint = "http://localhost:5000/api/v1.0/";

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetArtists()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}User/Artists/");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UserDto>>(resultText);
        }

        public async Task<List<ShowDto>> GetShows()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Show/");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ShowDto>>(resultText);
        }

        public async Task<List<ShowDto>> GetProfile(int id)
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}User/{id}");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ShowDto>>(resultText);
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Genre/");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GenreDto>>(resultText);
        }






    }
}
