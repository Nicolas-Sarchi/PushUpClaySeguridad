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
public class DireccionController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public DireccionController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
{
    var Direccion = await _unitOfWork.Direccions.GetAllAsync();
    return _mapper.Map<List<DireccionDto>>(Direccion);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DireccionDto>> Get(int id)
{
    var Direccion = await _unitOfWork.Direccions.GetByIdAsync(id);
    return _mapper.Map<DireccionDto>(Direccion);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<DireccionDto>>> Get([FromQuery]Params DireccionParams)
{
var Direccion = await _unitOfWork.Direccions.GetAllAsync(DireccionParams.PageIndex,DireccionParams.PageSize, DireccionParams.Search, "Id" );
var listaDireccionsDto= _mapper.Map<List<DireccionDto>>(Direccion.registros);
return new Pager<DireccionDto>(listaDireccionsDto, Direccion.totalRegistros,DireccionParams.PageIndex,DireccionParams.PageSize,DireccionParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Direccion>> Post(DireccionDto DireccionDto)
{
    var Direccion = _mapper.Map<Direccion>(DireccionDto);
    _unitOfWork.Direccions.Add(Direccion);
    await _unitOfWork.SaveAsync();

    if (Direccion == null)
    {
        return BadRequest();
    }
    DireccionDto.Id = Direccion.Id;
    return CreatedAtAction(nameof(Post), new { id = DireccionDto.Id }, Direccion);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody]DireccionDto DireccionDto)
{
    if (DireccionDto == null)
    {
        return NotFound();
    }
    var Direccion = _mapper.Map<Direccion>(DireccionDto);
    _unitOfWork.Direccions.Update(Direccion);
    await _unitOfWork.SaveAsync();
    return DireccionDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DireccionDto>> Delete(int id)
{
    var Direccion = await _unitOfWork.Direccions.GetByIdAsync(id);
    if (Direccion == null)
    {
        return NotFound();
    }
    _unitOfWork.Direccions.Remove(Direccion);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}