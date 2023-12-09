using AutoMapper;
using RestApp.DataAccess.Repository;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

namespace RestApp.Services
{
    public class RestaurantService : IRestaurantService
    {
        public readonly IRestaurantRepository _restaurantRepository;
        public readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(RestaurantDto restaurantDto)
        {
            var restaurantToAdd = _mapper.Map<Restaurant>(restaurantDto);
            return await _restaurantRepository.Create(restaurantToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var restaurantToDel = await _restaurantRepository.GetById(id);
            if (restaurantToDel == null)
            {
                return false;
            }
            await _restaurantRepository.Delete(restaurantToDel);
            return true;
        }

        public async Task<List<RestaurantDto>> GetAll()
        {
            var Restaurants = await _restaurantRepository.GetAll();
            return _mapper.Map<List<RestaurantDto>>(Restaurants);
        }

        public async Task<RestaurantDto> GetById(int id)
        {
            var restaurant = await _restaurantRepository.GetById(id);
            return _mapper.Map<RestaurantDto>(restaurant);
        }
        public async Task<RestaurantDto> GetByName(string name)
        {
            var restaurant = await _restaurantRepository.GetByName(name);
            return _mapper.Map<RestaurantDto>(restaurant);
        }
        public async Task<RestaurantDto> Update(RestaurantDto restaurantDto)
        {
            var restaurantToUpd = await _restaurantRepository.GetById(restaurantDto.Id);
            if (restaurantToUpd == null) { return null; }
            _mapper.Map(restaurantDto, restaurantToUpd);
            await _restaurantRepository.Update(restaurantToUpd);
            return _mapper.Map<RestaurantDto>(restaurantToUpd);
        }
    }
}