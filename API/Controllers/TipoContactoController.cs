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
public class TipoContactoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoContactoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
{
    var TipoContacto = await _unitOfWork.TiposContacto.GetAllAsync();
    return _mapper.Map<List<TipoContactoDto>>(TipoContacto);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoContactoDto>> Get(int id)
{
    var TipoContacto = await _unitOfWork.TiposContacto.GetByIdAsync(id);
    return _mapper.Map<TipoContactoDto>(TipoContacto);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoContactoDto>>> Get([FromQuery]Params TipoContactoParams)
{
var TipoContacto = await _unitOfWork.TiposContacto.GetAllAsync(TipoContactoParams.PageIndex,TipoContactoParams.PageSize, TipoContactoParams.Search, "Id" );
var listaTiposContactoDto= _mapper.Map<List<TipoContactoDto>>(TipoContacto.registros);
return new Pager<TipoContactoDto>(listaTiposContactoDto, TipoContacto.totalRegistros,TipoContactoParams.PageIndex,TipoContactoParams.PageSize,TipoContactoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto TipoContactoDto)
{
    var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
    _unitOfWork.TiposContacto.Add(TipoContacto);
    await _unitOfWork.SaveAsync();

    if (TipoContacto == null)
    {
        return BadRequest();
    }
    TipoContactoDto.Id = TipoContacto.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoContactoDto.Id }, TipoContacto);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody]TipoContactoDto TipoContactoDto)
{
    if (TipoContactoDto == null)
    {
        return NotFound();
    }
    var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
    _unitOfWork.TiposContacto.Update(TipoContacto);
    await _unitOfWork.SaveAsync();
    return TipoContactoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoContactoDto>> Delete(int id)
{
    var TipoContacto = await _unitOfWork.TiposContacto.GetByIdAsync(id);
    if (TipoContacto == null)
    {
        return NotFound();
    }
    _unitOfWork.TiposContacto.Remove(TipoContacto);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}