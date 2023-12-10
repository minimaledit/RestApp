using Azure;
using RestApp.ReservationDto;
using RestApp.Services.Contract;
using System.Net.Http.Json;

namespace RestApp.Web.Requests
{

    public class ApiRestaurantService : IRestaurantService
    {
        protected readonly HttpClient _httpClient;

        public ApiRestaurantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> Create(RestaurantDto restaurant)
        {
            var response = await _httpClient.PostAsJsonAsync("api/RestApp/Restaurant/Create", restaurant);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the restaurant object");
        }

        public async Task<RestaurantDto> GetById(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<RestaurantDto>($"api/RestApp/Restaurant/{id}");
            return response ?? throw new HttpRequestException($"Couldn't get restaurant with id {id}");
        }

        public async Task<RestaurantDto> GetByName(string name)
        {
            var response = await _httpClient.GetFromJsonAsync<RestaurantDto>($"api/RestApp/Restaurant/GETBYname/{name}");
            if (response != null) { return response; }
            else throw new HttpRequestException("Couldn't get restaurants");
        }
        public async Task<List<RestaurantDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<RestaurantDto>>($"api/RestApp/Restaurant/Restaurants");
            return response ?? throw new HttpRequestException("Couldn't get restaurants");
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/RestApp/Restaurant/Delete{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<RestaurantDto> Update(RestaurantDto restaurant)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/RestApp/Restaurant/Put", restaurant);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RestaurantDto>();
            }
            else
            {
                throw new HttpRequestException($"Couldn't update restaurant with id {restaurant.Id}");
            }
        }
        public async Task<List<TableDto>> GetTablesForRestaurant(int restaurantId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<TableDto>>($"api/RestApp/Restaurant/GetTables/{restaurantId}");
            return response ?? throw new HttpRequestException($"Couldn't get tables for restaurant with id {restaurantId}");
        }
    }
}