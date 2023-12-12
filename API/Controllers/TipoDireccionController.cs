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
public class TipoDireccionController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoDireccionController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoDireccionDto>>> Get()
{
    var TipoDireccion = await _unitOfWork.TiposDireccion.GetAllAsync();
    return _mapper.Map<List<TipoDireccionDto>>(TipoDireccion);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoDireccionDto>> Get(int id)
{
    var TipoDireccion = await _unitOfWork.TiposDireccion.GetByIdAsync(id);
    return _mapper.Map<TipoDireccionDto>(TipoDireccion);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoDireccionDto>>> Get([FromQuery]Params TipoDireccionParams)
{
var TipoDireccion = await _unitOfWork.TiposDireccion.GetAllAsync(TipoDireccionParams.PageIndex,TipoDireccionParams.PageSize, TipoDireccionParams.Search, "Id" );
var listaTiposDireccionDto= _mapper.Map<List<TipoDireccionDto>>(TipoDireccion.registros);
return new Pager<TipoDireccionDto>(listaTiposDireccionDto, TipoDireccion.totalRegistros,TipoDireccionParams.PageIndex,TipoDireccionParams.PageSize,TipoDireccionParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoDireccion>> Post(TipoDireccionDto TipoDireccionDto)
{
    var TipoDireccion = _mapper.Map<TipoDireccion>(TipoDireccionDto);
    _unitOfWork.TiposDireccion.Add(TipoDireccion);
    await _unitOfWork.SaveAsync();

    if (TipoDireccion == null)
    {
        return BadRequest();
    }
    TipoDireccionDto.Id = TipoDireccion.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoDireccionDto.Id }, TipoDireccion);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoDireccionDto>> Put(int id, [FromBody]TipoDireccionDto TipoDireccionDto)
{
    if (TipoDireccionDto == null)
    {
        return NotFound();
    }
    var TipoDireccion = _mapper.Map<TipoDireccion>(TipoDireccionDto);
    _unitOfWork.TiposDireccion.Update(TipoDireccion);
    await _unitOfWork.SaveAsync();
    return TipoDireccionDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoDireccionDto>> Delete(int id)
{
    var TipoDireccion = await _unitOfWork.TiposDireccion.GetByIdAsync(id);
    if (TipoDireccion == null)
    {
        return NotFound();
    }
    _unitOfWork.TiposDireccion.Remove(TipoDireccion);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}