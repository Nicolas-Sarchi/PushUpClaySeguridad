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
public class CiudadController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public CiudadController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
{
    var Ciudad = await _unitOfWork.Ciudads.GetAllAsync();
    return _mapper.Map<List<CiudadDto>>(Ciudad);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CiudadDto>> Get(int id)
{
    var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);
    return _mapper.Map<CiudadDto>(Ciudad);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<CiudadDto>>> Get([FromQuery]Params CiudadParams)
{
var Ciudad = await _unitOfWork.Ciudads.GetAllAsync(CiudadParams.PageIndex,CiudadParams.PageSize, CiudadParams.Search, "NombreCiu" );
var listaCiudadsDto= _mapper.Map<List<CiudadDto>>(Ciudad.registros);
return new Pager<CiudadDto>(listaCiudadsDto, Ciudad.totalRegistros,CiudadParams.PageIndex,CiudadParams.PageSize,CiudadParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto)
{
    var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
    _unitOfWork.Ciudads.Add(Ciudad);
    await _unitOfWork.SaveAsync();

    if (Ciudad == null)
    {
        return BadRequest();
    }
    CiudadDto.Id = Ciudad.Id;
    return CreatedAtAction(nameof(Post), new { id = CiudadDto.Id }, Ciudad);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody]CiudadDto CiudadDto)
{
    if (CiudadDto == null)
    {
        return NotFound();
    }
    var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
    _unitOfWork.Ciudads.Update(Ciudad);
    await _unitOfWork.SaveAsync();
    return CiudadDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CiudadDto>> Delete(int id)
{
    var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);
    if (Ciudad == null)
    {
        return NotFound();
    }
    _unitOfWork.Ciudads.Remove(Ciudad);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}