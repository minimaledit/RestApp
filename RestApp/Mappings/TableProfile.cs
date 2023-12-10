using AutoMapper;
using RestApp.Entities;
using RestApp.ReservationDto;

namespace RestApp.Mappings
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<Table, CreateTableDto>().ReverseMap();
        }
    }
}
