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
public class DepartamentoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public DepartamentoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
{
    var Departamento = await _unitOfWork.Departamentos.GetAllAsync();
    return _mapper.Map<List<DepartamentoDto>>(Departamento);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DepartamentoDto>> Get(int id)
{
    var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
    return _mapper.Map<DepartamentoDto>(Departamento);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<DepartamentoDto>>> Get([FromQuery]Params DepartamentoParams)
{
var Departamento = await _unitOfWork.Departamentos.GetAllAsync(DepartamentoParams.PageIndex,DepartamentoParams.PageSize, DepartamentoParams.Search, "Id" );
var listaDepartamentosDto= _mapper.Map<List<DepartamentoDto>>(Departamento.registros);
return new Pager<DepartamentoDto>(listaDepartamentosDto, Departamento.totalRegistros,DepartamentoParams.PageIndex,DepartamentoParams.PageSize,DepartamentoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
{
    var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
    _unitOfWork.Departamentos.Add(Departamento);
    await _unitOfWork.SaveAsync();

    if (Departamento == null)
    {
        return BadRequest();
    }
    DepartamentoDto.Id = Departamento.Id;
    return CreatedAtAction(nameof(Post), new { id = DepartamentoDto.Id }, Departamento);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto)
{
    if (DepartamentoDto == null)
    {
        return NotFound();
    }
    var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
    _unitOfWork.Departamentos.Update(Departamento);
    await _unitOfWork.SaveAsync();
    return DepartamentoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DepartamentoDto>> Delete(int id)
{
    var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
    if (Departamento == null)
    {
        return NotFound();
    }
    _unitOfWork.Departamentos.Remove(Departamento);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}