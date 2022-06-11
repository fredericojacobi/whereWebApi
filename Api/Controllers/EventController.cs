using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;

    public EventController(ILogger<EventController> logger) => _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {
        return Ok();
    }

}