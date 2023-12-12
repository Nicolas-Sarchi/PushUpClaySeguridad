using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Linq;
using API.Helpers;
namespace API.Controllers
{
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]
public class EmpleadoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public EmpleadoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
{
    var Empleado = await _unitOfWork.Empleados.GetAllAsync();
    return _mapper.Map<List<EmpleadoDto>>(Empleado);
}

[HttpGet("Vigilantes")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetVigilantes()
{
    var Empleado = await _unitOfWork.Empleados.GetVigilantes();
    return _mapper.Map<List<EmpleadoDto>>(Empleado);
}

[HttpGet("GironyPiedecuesta")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetGironPiedecuesta()
{
    var Empleado = await _unitOfWork.Empleados.GetGironPiedecuesta();
    return _mapper.Map<List<EmpleadoDto>>(Empleado);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpleadoDto>> Get(int id)
{
    var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
    return _mapper.Map<EmpleadoDto>(Empleado);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<EmpleadoDto>>> Get([FromQuery]Params EmpleadoParams)
{
var Empleado = await _unitOfWork.Empleados.GetAllAsync(EmpleadoParams.PageIndex,EmpleadoParams.PageSize, EmpleadoParams.Search, "Id" );
var listaEmpleadosDto= _mapper.Map<List<EmpleadoDto>>(Empleado.registros);
return new Pager<EmpleadoDto>(listaEmpleadosDto, Empleado.totalRegistros,EmpleadoParams.PageIndex,EmpleadoParams.PageSize,EmpleadoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
{
    var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
    _unitOfWork.Empleados.Add(Empleado);
    await _unitOfWork.SaveAsync();

    if (Empleado == null)
    {
        return BadRequest();
    }
    EmpleadoDto.Id = Empleado.Id;
    return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, Empleado);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto EmpleadoDto)
{
    if (EmpleadoDto == null)
    {
        return NotFound();
    }
    var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
    _unitOfWork.Empleados.Update(Empleado);
    await _unitOfWork.SaveAsync();
    return EmpleadoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpleadoDto>> Delete(int id)
{
    var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
    if (Empleado == null)
    {
        return NotFound();
    }
    _unitOfWork.Empleados.Remove(Empleado);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}