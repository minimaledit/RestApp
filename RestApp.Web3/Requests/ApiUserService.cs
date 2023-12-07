using RestApp.ReservationDto;
using RestApp.Services.Contract;
using System.Net.Http.Json;

namespace RestApp.Web.Requests
{

    public class ApiUserService : IUserService
    {
        protected readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> Create(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("User", user);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the user object");
        }

        public async Task<UserDto> GetById(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<UserDto>($"User/{id}");
            return response ?? throw new HttpRequestException($"Couldn't get user with id {id}");
        }

        public async Task<List<UserDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<UserDto>>($"User");
            return response ?? throw new HttpRequestException("Couldn't get users");
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"User/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<UserDto> Update(UserDto user)
        {
            var response = await _httpClient.PutAsJsonAsync($"User/{user.Id}", user);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            else
            {
                throw new HttpRequestException($"Couldn't update user with id {user.Id}");
            }
        }
    }
}