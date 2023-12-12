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
public class TipoViaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoViaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoViaDto>>> Get()
{
    var TipoVia = await _unitOfWork.TiposVia.GetAllAsync();
    return _mapper.Map<List<TipoViaDto>>(TipoVia);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoViaDto>> Get(int id)
{
    var TipoVia = await _unitOfWork.TiposVia.GetByIdAsync(id);
    return _mapper.Map<TipoViaDto>(TipoVia);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoViaDto>>> Get([FromQuery]Params TipoViaParams)
{
var TipoVia = await _unitOfWork.TiposVia.GetAllAsync(TipoViaParams.PageIndex,TipoViaParams.PageSize, TipoViaParams.Search, "Id" );
var listaTiposViaDto= _mapper.Map<List<TipoViaDto>>(TipoVia.registros);
return new Pager<TipoViaDto>(listaTiposViaDto, TipoVia.totalRegistros,TipoViaParams.PageIndex,TipoViaParams.PageSize,TipoViaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoVia>> Post(TipoViaDto TipoViaDto)
{
    var TipoVia = _mapper.Map<TipoVia>(TipoViaDto);
    _unitOfWork.TiposVia.Add(TipoVia);
    await _unitOfWork.SaveAsync();

    if (TipoVia == null)
    {
        return BadRequest();
    }
    TipoViaDto.Id = TipoVia.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoViaDto.Id }, TipoVia);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoViaDto>> Put(int id, [FromBody]TipoViaDto TipoViaDto)
{
    if (TipoViaDto == null)
    {
        return NotFound();
    }
    var TipoVia = _mapper.Map<TipoVia>(TipoViaDto);
    _unitOfWork.TiposVia.Update(TipoVia);
    await _unitOfWork.SaveAsync();
    return TipoViaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoViaDto>> Delete(int id)
{
    var TipoVia = await _unitOfWork.TiposVia.GetByIdAsync(id);
    if (TipoVia == null)
    {
        return NotFound();
    }
    _unitOfWork.TiposVia.Remove(TipoVia);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}