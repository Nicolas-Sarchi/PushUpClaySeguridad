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
public class ClienteController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public ClienteController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
{
    var Cliente = await _unitOfWork.Clientes.GetAllAsync();
    return _mapper.Map<List<ClienteDto>>(Cliente);
}

[HttpGet("bucaramanga")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClienteDto>>> Getbucaramanga()
{
    var Cliente = await _unitOfWork.Clientes.GetBucaramanga();
    return _mapper.Map<List<ClienteDto>>(Cliente);
}

[HttpGet("Mas5Ahos")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClienteDto>>> GetMas5Ahos()
{
    var Cliente = await _unitOfWork.Clientes.GetMas5anhos();
    return _mapper.Map<List<ClienteDto>>(Cliente);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ClienteDto>> Get(int id)
{
    var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
    return _mapper.Map<ClienteDto>(Cliente);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<ClienteDto>>> Get([FromQuery]Params ClienteParams)
{
var Cliente = await _unitOfWork.Clientes.GetAllAsync(ClienteParams.PageIndex,ClienteParams.PageSize, ClienteParams.Search, "Id" );
var listaClientesDto= _mapper.Map<List<ClienteDto>>(Cliente.registros);
return new Pager<ClienteDto>(listaClientesDto, Cliente.totalRegistros,ClienteParams.PageIndex,ClienteParams.PageSize,ClienteParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
{
    var Cliente = _mapper.Map<Cliente>(ClienteDto);
    _unitOfWork.Clientes.Add(Cliente);
    await _unitOfWork.SaveAsync();

    if (Cliente == null)
    {
        return BadRequest();
    }
    ClienteDto.Id = Cliente.Id;
    return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, Cliente);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto ClienteDto)
{
    if (ClienteDto == null)
    {
        return NotFound();
    }
    var Cliente = _mapper.Map<Cliente>(ClienteDto);
    _unitOfWork.Clientes.Update(Cliente);
    await _unitOfWork.SaveAsync();
    return ClienteDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ClienteDto>> Delete(int id)
{
    var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
    if (Cliente == null)
    {
        return NotFound();
    }
    _unitOfWork.Clientes.Remove(Cliente);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}