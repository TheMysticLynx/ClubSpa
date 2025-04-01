using ClubSpaApi.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebApplication.Controllers;

[ApiController]
[Route("api")]
public class ClubSpaController : ControllerBase
{
    private readonly ClubSpaService _clubSpaService;
    
    public ClubSpaController(ClubSpaService clubSpaService)
    {
        Log.Information("Creating ClubSpaController");
        _clubSpaService = clubSpaService;
    }
    
    [HttpPost("startWash")]
    public Task<IActionResult> StartWash(int seconds)
    {
        Log.Information("Starting spa with interval {interval}", seconds);
        _ = Task.Run(async () =>
        {
            await _clubSpaService.Start(TimeSpan.FromSeconds(seconds));
        });
        return Task.FromResult<IActionResult>(Ok());
    }
    
    [HttpPost("stop")]
    public async Task<IActionResult> Stop()
    {
        try
        {
            await _clubSpaService.Stop();
            return Ok();
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}