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
public class CategoriaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public CategoriaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
{
    var Categoria = await _unitOfWork.Categorias.GetAllAsync();
    return _mapper.Map<List<CategoriaDto>>(Categoria);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CategoriaDto>> Get(int id)
{
    var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
    return _mapper.Map<CategoriaDto>(Categoria);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<CategoriaDto>>> Get([FromQuery]Params CategoriaParams)
{
var Categoria = await _unitOfWork.Categorias.GetAllAsync(CategoriaParams.PageIndex,CategoriaParams.PageSize, CategoriaParams.Search, "Id" );
var listaCategoriasDto= _mapper.Map<List<CategoriaDto>>(Categoria.registros);
return new Pager<CategoriaDto>(listaCategoriasDto, Categoria.totalRegistros,CategoriaParams.PageIndex,CategoriaParams.PageSize,CategoriaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Categoria>> Post(CategoriaDto CategoriaDto)
{
    var Categoria = _mapper.Map<Categoria>(CategoriaDto);
    _unitOfWork.Categorias.Add(Categoria);
    await _unitOfWork.SaveAsync();

    if (Categoria == null)
    {
        return BadRequest();
    }
    CategoriaDto.Id = Categoria.Id;
    return CreatedAtAction(nameof(Post), new { id = CategoriaDto.Id }, Categoria);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody]CategoriaDto CategoriaDto)
{
    if (CategoriaDto == null)
    {
        return NotFound();
    }
    var Categoria = _mapper.Map<Categoria>(CategoriaDto);
    _unitOfWork.Categorias.Update(Categoria);
    await _unitOfWork.SaveAsync();
    return CategoriaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CategoriaDto>> Delete(int id)
{
    var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
    if (Categoria == null)
    {
        return NotFound();
    }
    _unitOfWork.Categorias.Remove(Categoria);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}