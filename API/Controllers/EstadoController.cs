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
public class EstadoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public EstadoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
{
    var Estado = await _unitOfWork.Estados.GetAllAsync();
    return _mapper.Map<List<EstadoDto>>(Estado);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EstadoDto>> Get(int id)
{
    var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
    return _mapper.Map<EstadoDto>(Estado);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<EstadoDto>>> Get([FromQuery]Params EstadoParams)
{
var Estado = await _unitOfWork.Estados.GetAllAsync(EstadoParams.PageIndex,EstadoParams.PageSize, EstadoParams.Search, "Id" );
var listaEstadosDto= _mapper.Map<List<EstadoDto>>(Estado.registros);
return new Pager<EstadoDto>(listaEstadosDto, Estado.totalRegistros,EstadoParams.PageIndex,EstadoParams.PageSize,EstadoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
{
    var Estado = _mapper.Map<Estado>(EstadoDto);
    _unitOfWork.Estados.Add(Estado);
    await _unitOfWork.SaveAsync();

    if (Estado == null)
    {
        return BadRequest();
    }
    EstadoDto.Id = Estado.Id;
    return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, Estado);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto EstadoDto)
{
    if (EstadoDto == null)
    {
        return NotFound();
    }
    var Estado = _mapper.Map<Estado>(EstadoDto);
    _unitOfWork.Estados.Update(Estado);
    await _unitOfWork.SaveAsync();
    return EstadoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EstadoDto>> Delete(int id)
{
    var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
    if (Estado == null)
    {
        return NotFound();
    }
    _unitOfWork.Estados.Remove(Estado);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}