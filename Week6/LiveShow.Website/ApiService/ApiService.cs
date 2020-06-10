using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.Notification;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<ShowDto> GetProfile(int id)
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}User/{id}");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ShowDto>(resultText);
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Genre/");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GenreDto>>(resultText);
        }

        public async Task<HttpResponseMessage> AddGenre(HttpContent genre)
        {
            var genreToJson = JsonConvert.SerializeObject(genre);
            var content = new StringContent(genreToJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync($"{apiEndpoint}/Genre/", content);
            return result;
        }

        public async Task<HttpResponseMessage> DeleteGenre(int genreId)
        {
            var result = await httpClient.DeleteAsync($"{apiEndpoint}/Genre/{genreId}");
            return result;
        }

        public async Task<HttpResponseMessage> Follow(FollowerDto follower)
        {
            var followerToJson = JsonConvert.SerializeObject(follower);
            var content = new StringContent(followerToJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync($"{apiEndpoint}/Follow/", content);
            return result;
        }

        public async Task<HttpResponseMessage> CreateNotification(HttpContent notification)
        {
            var notificationToJson = JsonConvert.SerializeObject(notification);
            var content = new StringContent(notificationToJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync($"{apiEndpoint}/Notification/", content);
            return result;
        }

        public async Task<HttpResponseMessage> Unfollow(int followerId)
        {
            var result = await httpClient.DeleteAsync($"{apiEndpoint}/Follow/{followerId}");
            return result;
        }

        //Delete Follower

        public async Task<NotificationDto> GetNotification(int notificationId)
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Notification/{notificationId}");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NotificationDto>(resultText);
        }

        public async Task<List<NotificationDto>> GetNotification()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Notification/");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<NotificationDto>>(resultText);
        }

        public async Task<List<UserDto>> GetAllShowsByVenue(string venue)
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Show/{venue}");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UserDto>>(resultText);
        }

        public async Task<List<UserDto>> GetAllShowsByArtist(string venue)
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiEndpoint}Show/{venue}");

            string resultText = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UserDto>>(resultText);
        }





        public async Task<HttpResponseMessage> Register(UserDto userDto)
        {
            var userToJson = JsonConvert.SerializeObject(userDto);
            HttpContent c = new StringContent(userToJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync($"{apiEndpoint}/User/register/", c);
            return result;
        }

        public async Task<HttpResponseMessage> Login(UserDto user)
        {
            var userToJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(userToJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync($"{apiEndpoint}/User/login/", content);
            return result;
        }


    }
}