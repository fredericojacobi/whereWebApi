using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.UserApplication;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserApplicationController : ControllerBase
{
    private readonly ILogger<UserApplicationController> _logger;
    private readonly IUserApplicationService _service;

    public UserApplicationController(ILogger<UserApplicationController> logger, IUserApplicationService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        return Ok(await _service.GetAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserApplicationRegisterDTO dto)
    {
        return Ok(await _service.PostAsync(dto));
    }
}