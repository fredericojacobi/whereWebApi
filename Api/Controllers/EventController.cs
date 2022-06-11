using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Event;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly IServiceWrapper _service;

    public EventController(ILogger<EventController> logger, IServiceWrapper service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] int? max_records = null)
    {
        _logger.LogCritical($"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")}: {nameof(GetAsync)}");
        return Ok(await _service.Event.GetAllAsync(max_records));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        return Ok(await _service.Event.GetAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] EventRegisterDTO dto)
    {
        return Ok(await _service.Event.PostAsync(dto));
    }
}