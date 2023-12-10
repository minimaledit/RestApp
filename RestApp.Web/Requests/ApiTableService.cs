using Azure;
using RestApp.ReservationDto;
using RestApp.Services.Contract;
using System.Net.Http.Json;

namespace RestApp.Web.Requests
{

    public class ApiTableService : ITableService
    {
        protected readonly HttpClient _httpClient;

        public ApiTableService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> Create(TableDto table)
        {
            var response = await _httpClient.PostAsJsonAsync("api/RestApp/Table/Create", table);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the table object");
        }

        public async Task<TableDto> GetById(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<TableDto>($"api/RestApp/Table/GETBYid{id}");
            return response ?? throw new HttpRequestException($"Couldn't get table with id {id}");
        }
        public async Task<List<TableDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TableDto>>($"api/RestApp/Table/Tables");
            return response ?? throw new HttpRequestException("Couldn't get tables");
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/RestApp/Table/Delete{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<TableDto> Update(TableDto table)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/RestApp/Table/Put", table);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TableDto>();
            }
            else
            {
                throw new HttpRequestException($"Couldn't update table with id {table.Id}");
            }
        }
    }
}