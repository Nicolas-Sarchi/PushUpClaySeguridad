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
public class ProgramacionController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public ProgramacionController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
{
    var Programacion = await _unitOfWork.Programaciones.GetAllAsync();
    return _mapper.Map<List<ProgramacionDto>>(Programacion);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ProgramacionDto>> Get(int id)
{
    var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
    return _mapper.Map<ProgramacionDto>(Programacion);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<ProgramacionDto>>> Get([FromQuery]Params ProgramacionParams)
{
var Programacion = await _unitOfWork.Programaciones.GetAllAsync(ProgramacionParams.PageIndex,ProgramacionParams.PageSize, ProgramacionParams.Search, "Id" );
var listaProgramacionesDto= _mapper.Map<List<ProgramacionDto>>(Programacion.registros);
return new Pager<ProgramacionDto>(listaProgramacionesDto, Programacion.totalRegistros,ProgramacionParams.PageIndex,ProgramacionParams.PageSize,ProgramacionParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Programacion>> Post(ProgramacionDto ProgramacionDto)
{
    var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
    _unitOfWork.Programaciones.Add(Programacion);
    await _unitOfWork.SaveAsync();

    if (Programacion == null)
    {
        return BadRequest();
    }
    ProgramacionDto.Id = Programacion.Id;
    return CreatedAtAction(nameof(Post), new { id = ProgramacionDto.Id }, Programacion);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody]ProgramacionDto ProgramacionDto)
{
    if (ProgramacionDto == null)
    {
        return NotFound();
    }
    var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
    _unitOfWork.Programaciones.Update(Programacion);
    await _unitOfWork.SaveAsync();
    return ProgramacionDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ProgramacionDto>> Delete(int id)
{
    var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
    if (Programacion == null)
    {
        return NotFound();
    }
    _unitOfWork.Programaciones.Remove(Programacion);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}