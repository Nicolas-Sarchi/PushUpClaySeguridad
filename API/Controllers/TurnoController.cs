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
public class TurnoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TurnoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
{
    var Turno = await _unitOfWork.Turnos.GetAllAsync();
    return _mapper.Map<List<TurnoDto>>(Turno);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TurnoDto>> Get(int id)
{
    var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
    return _mapper.Map<TurnoDto>(Turno);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TurnoDto>>> Get([FromQuery]Params TurnoParams)
{
var Turno = await _unitOfWork.Turnos.GetAllAsync(TurnoParams.PageIndex,TurnoParams.PageSize, TurnoParams.Search, "Id" );
var listaTurnosDto= _mapper.Map<List<TurnoDto>>(Turno.registros);
return new Pager<TurnoDto>(listaTurnosDto, Turno.totalRegistros,TurnoParams.PageIndex,TurnoParams.PageSize,TurnoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Turno>> Post(TurnoDto TurnoDto)
{
    var Turno = _mapper.Map<Turno>(TurnoDto);
    _unitOfWork.Turnos.Add(Turno);
    await _unitOfWork.SaveAsync();

    if (Turno == null)
    {
        return BadRequest();
    }
    TurnoDto.Id = Turno.Id;
    return CreatedAtAction(nameof(Post), new { id = TurnoDto.Id }, Turno);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody]TurnoDto TurnoDto)
{
    if (TurnoDto == null)
    {
        return NotFound();
    }
    var Turno = _mapper.Map<Turno>(TurnoDto);
    _unitOfWork.Turnos.Update(Turno);
    await _unitOfWork.SaveAsync();
    return TurnoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TurnoDto>> Delete(int id)
{
    var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
    if (Turno == null)
    {
        return NotFound();
    }
    _unitOfWork.Turnos.Remove(Turno);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}