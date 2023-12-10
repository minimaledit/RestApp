using RestApp.ReservationDto;

namespace RestApp.Services.Contract
{
    public interface ITableService
    {
        Task<TableDto> GetById(int id);
        Task<List<TableDto>> GetAll();
        Task<int> Create(TableDto tableDto);
        Task<TableDto> Update(TableDto tableDto);
        Task<bool> Delete(int id);
    }
}
