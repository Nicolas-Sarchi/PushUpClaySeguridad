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
public class ContratoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public ContratoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ContratoDto>>> Get()
{
    var Contrato = await _unitOfWork.Contratos.GetAllAsync();
    return _mapper.Map<List<ContratoDto>>(Contrato);
}

[HttpGet("activos")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ContratoActivoDto>>> GetActivos()
{
    var Contrato = await _unitOfWork.Contratos.GetActivos();
    return _mapper.Map<List<ContratoActivoDto>>(Contrato);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContratoDto>> Get(int id)
{
    var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
    return _mapper.Map<ContratoDto>(Contrato);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<ContratoDto>>> Get([FromQuery]Params ContratoParams)
{
var Contrato = await _unitOfWork.Contratos.GetAllAsync(ContratoParams.PageIndex,ContratoParams.PageSize, ContratoParams.Search, "Id" );
var listaContratosDto= _mapper.Map<List<ContratoDto>>(Contrato.registros);
return new Pager<ContratoDto>(listaContratosDto, Contrato.totalRegistros,ContratoParams.PageIndex,ContratoParams.PageSize,ContratoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Contrato>> Post(ContratoDto ContratoDto)
{
    var Contrato = _mapper.Map<Contrato>(ContratoDto);
    _unitOfWork.Contratos.Add(Contrato);
    await _unitOfWork.SaveAsync();

    if (Contrato == null)
    {
        return BadRequest();
    }
    ContratoDto.Id = Contrato.Id;
    return CreatedAtAction(nameof(Post), new { id = ContratoDto.Id }, Contrato);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody]ContratoDto ContratoDto)
{
    if (ContratoDto == null)
    {
        return NotFound();
    }
    var Contrato = _mapper.Map<Contrato>(ContratoDto);
    _unitOfWork.Contratos.Update(Contrato);
    await _unitOfWork.SaveAsync();
    return ContratoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContratoDto>> Delete(int id)
{
    var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
    if (Contrato == null)
    {
        return NotFound();
    }
    _unitOfWork.Contratos.Remove(Contrato);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}