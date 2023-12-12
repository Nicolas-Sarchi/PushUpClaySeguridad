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
public class PaisController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public PaisController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
{
    var Pais = await _unitOfWork.Paises.GetAllAsync();
    return _mapper.Map<List<PaisDto>>(Pais);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<PaisDto>> Get(int id)
{
    var Pais = await _unitOfWork.Paises.GetByIdAsync(id);
    return _mapper.Map<PaisDto>(Pais);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<PaisDto>>> Get([FromQuery]Params PaisParams)
{
var Pais = await _unitOfWork.Paises.GetAllAsync(PaisParams.PageIndex,PaisParams.PageSize, PaisParams.Search, "Id" );
var listaPaisesDto= _mapper.Map<List<PaisDto>>(Pais.registros);
return new Pager<PaisDto>(listaPaisesDto, Pais.totalRegistros,PaisParams.PageIndex,PaisParams.PageSize,PaisParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
{
    var Pais = _mapper.Map<Pais>(PaisDto);
    _unitOfWork.Paises.Add(Pais);
    await _unitOfWork.SaveAsync();

    if (Pais == null)
    {
        return BadRequest();
    }
    PaisDto.Id = Pais.Id;
    return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, Pais);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto PaisDto)
{
    if (PaisDto == null)
    {
        return NotFound();
    }
    var Pais = _mapper.Map<Pais>(PaisDto);
    _unitOfWork.Paises.Update(Pais);
    await _unitOfWork.SaveAsync();
    return PaisDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<PaisDto>> Delete(int id)
{
    var Pais = await _unitOfWork.Paises.GetByIdAsync(id);
    if (Pais == null)
    {
        return NotFound();
    }
    _unitOfWork.Paises.Remove(Pais);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}