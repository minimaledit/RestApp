using RestApp.ReservationDto;

namespace RestApp.Services.Contract
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetAll();
        Task<int> Create(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task<bool> Delete(int id);
    }
}
