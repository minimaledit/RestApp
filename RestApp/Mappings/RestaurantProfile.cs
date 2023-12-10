using AutoMapper;
using RestApp.Entities;
using RestApp.ReservationDto;

namespace RestApp.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Restaurant, CreateRestaurantDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<Table, CreateTableDto>().ReverseMap();
        }
    }
}
