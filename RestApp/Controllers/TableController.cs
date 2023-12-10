using Microsoft.AspNetCore.Mvc;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

[ApiController]
[Route("api/RestApp/Table")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;
    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }
    // GET: api/RestApp/Table/Tables
    [HttpGet("Tables")]
    public async Task<ActionResult<List<TableDto>>> GetTables()
    {
        var tables = await _tableService.GetAll();
        return Ok(tables);
    }
    // GET: api/RestApp/Table/GETBYid/{id}
    [HttpGet("GETBYid/{id}")]
    public async Task<ActionResult<TableDto>> GetTable(int id)
    {
        var table = await _tableService.GetById(id);
        return table != null ? Ok(table) : NotFound();
    }
    // POST: api/RestApp/Table/Create
    [HttpPost("Create")]
    public async Task<ActionResult<TableDto>> CreateTable([FromBody] TableDto tableDto)
    {
        var createdTable = await _tableService.Create(tableDto);
        return Ok(createdTable);
    }
    // PUT: api/RestApp/Table/Put
    [HttpPut("Put")]
    public async Task<IActionResult> UpdateTable([FromBody] TableDto tableDto)
    {
        var updatedTable = await _tableService.Update(tableDto);
        return updatedTable != null ? Ok(updatedTable) : NotFound();
    }
    // DELETE: api/RestApp/Table/Delete{id}
    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> DeleteTable(int id)
    {
        var result = await _tableService.Delete(id);
        return result ? Ok(result) : NotFound();
    }
}
