using RestApp.ReservationDto;

namespace RestApp.Services.Contract
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GetById(int id);
        Task<List<RestaurantDto>> GetAll();
        Task<int> Create(RestaurantDto restaurantDto);
        Task<RestaurantDto> Update(RestaurantDto restaurantDto);
        Task<bool> Delete(int id);
        Task<RestaurantDto> GetByName(string name);
        Task<List<TableDto>> GetTablesForRestaurant(int restaurantId);
    }
}
