#region

using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApplication.Services;

#endregion

namespace WebApplication.Controllers;

[ApiController]
public class ClubSpaController : ControllerBase
{
    private readonly ClubSpaService _clubSpaService;

    public ClubSpaController(ClubSpaService clubSpaService)
    {
        Log.Information("Creating ClubSpaController");
        _clubSpaService = clubSpaService;
    }

    [HttpPost("/start/{seconds}")]
    public Task<IActionResult> StartWash(int seconds)
    {
        Log.Information("Starting spa with interval {interval}", seconds);
        _clubSpaService.ThrowIfCantStart();
        _ = Task.Run(async () => { await _clubSpaService.Start(TimeSpan.FromSeconds(seconds)); });
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpPost("stop")]
    public async Task<IActionResult> Stop()
    {
        try
        {
            await _clubSpaService.Stop();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}