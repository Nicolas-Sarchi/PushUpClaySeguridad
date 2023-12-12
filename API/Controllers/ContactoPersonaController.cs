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
public class ContactoPersonaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public ContactoPersonaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
{
    var ContactoPersona = await _unitOfWork.ContactoPersonas.GetAllAsync();
    return _mapper.Map<List<ContactoPersonaDto>>(ContactoPersona);
}

[HttpGet("vigilantes")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Getvigilantes()
{
    var ContactoPersona = await _unitOfWork.ContactoPersonas.GetContactosVigilantes();
    return _mapper.Map<List<ContactoPersonaDto>>(ContactoPersona);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
{
    var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
    return _mapper.Map<ContactoPersonaDto>(ContactoPersona);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<ContactoPersonaDto>>> Get([FromQuery]Params ContactoPersonaParams)
{
var ContactoPersona = await _unitOfWork.ContactoPersonas.GetAllAsync(ContactoPersonaParams.PageIndex,ContactoPersonaParams.PageSize, ContactoPersonaParams.Search, "Id" );
var listaContactoPersonasDto= _mapper.Map<List<ContactoPersonaDto>>(ContactoPersona.registros);
return new Pager<ContactoPersonaDto>(listaContactoPersonasDto, ContactoPersona.totalRegistros,ContactoPersonaParams.PageIndex,ContactoPersonaParams.PageSize,ContactoPersonaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContactoPersona>> Post(ContactoPersonaDto ContactoPersonaDto)
{
    var ContactoPersona = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
    _unitOfWork.ContactoPersonas.Add(ContactoPersona);
    await _unitOfWork.SaveAsync();

    if (ContactoPersona == null)
    {
        return BadRequest();
    }
    ContactoPersonaDto.Id = ContactoPersona.Id;
    return CreatedAtAction(nameof(Post), new { id = ContactoPersonaDto.Id }, ContactoPersona);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody]ContactoPersonaDto ContactoPersonaDto)
{
    if (ContactoPersonaDto == null)
    {
        return NotFound();
    }
    var ContactoPersona = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
    _unitOfWork.ContactoPersonas.Update(ContactoPersona);
    await _unitOfWork.SaveAsync();
    return ContactoPersonaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ContactoPersonaDto>> Delete(int id)
{
    var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
    if (ContactoPersona == null)
    {
        return NotFound();
    }
    _unitOfWork.ContactoPersonas.Remove(ContactoPersona);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}