using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class UserController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private IUserService _userService;
    public UserController(IUnitOfWork UnitOfWork, IMapper Mapper, IUserService userService)
    {
        _unitOfWork = UnitOfWork;
        _mapper = Mapper;
        _userService = userService;
    }

    [Authorize]
    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DataUserDto>>> Get()
    {
        var varName = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<List<DataUserDto>>(varName);
    }

    [Authorize]
    [ApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DataUserDto>>> Get11([FromQuery] Params UserParams)
    {
        var User = await _unitOfWork.Users.GetAllAsync(UserParams.PageIndex, UserParams.PageSize, UserParams.Search, "Username");
        var listaUsersDto = _mapper.Map<List<DataUserDto>>(User.registros);
        return new Pager<DataUserDto>(listaUsersDto, User.totalRegistros, UserParams.PageIndex, UserParams.PageSize, UserParams.Search);
    }
    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
    {
        var result = await _userService.AddRoleAsync(model);
        return Ok(result);
    }
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

} 