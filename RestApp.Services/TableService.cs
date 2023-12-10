using AutoMapper;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

namespace RestApp.Services
{
    public class TableService : ITableService
    {
        public readonly ITableRepository _tableRepository;
        public readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(TableDto tableDto)
        {
            var tableToAdd = _mapper.Map<Table>(tableDto);
            return await _tableRepository.Create(tableToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var tableToDel = await _tableRepository.GetById(id);
            if (tableToDel == null)
            {
                return false;
            }
            await _tableRepository.Delete(tableToDel);
            return true;
        }

        public async Task<List<TableDto>> GetAll()
        {
            var Tables = await _tableRepository.GetAll();
            return _mapper.Map<List<TableDto>>(Tables);
        }

        public async Task<TableDto> GetById(int id)
        {
            var table = await _tableRepository.GetById(id);
            return _mapper.Map<TableDto>(table);
        }
        public async Task<TableDto> Update(TableDto tableDto)
        {
            var tableToUpd = await _tableRepository.GetById(tableDto.Id);
            if (tableToUpd == null) { return null; }
            _mapper.Map(tableDto, tableToUpd);
            await _tableRepository.Update(tableToUpd);
            return _mapper.Map<TableDto>(tableToUpd);
        }
    }
}