using AutoMapper;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

namespace RestApp.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<int> Create(UserDto userDto)
        {
            var userToAdd = _mapper.Map<User>(userDto);
            return await _userRepository.Create(userToAdd);
        }
        public async Task<bool> Delete(int id)
        {
            var userToDel = await _userRepository.GetById(id);
            if(userToDel == null)
            {
                return false;
            }
            await _userRepository.Delete(userToDel);
            return true;
        }
        public async Task<List<UserDto>> GetAll()
        {
            var Users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(Users);
        }
        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> Update(UserDto userDto)
        {
            var userToUpd = await _userRepository.GetById(userDto.Id);
            if(userToUpd == null) {  return null; }
            _mapper.Map(userDto,userToUpd);
            await _userRepository.Update(userToUpd);
            return _mapper.Map<UserDto>(userToUpd);
        }
    }
}