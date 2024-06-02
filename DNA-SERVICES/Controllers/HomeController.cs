using DNA_SERVICES.Application.Interface;
using DNA_SERVICES.Contracts.Input.FeeSchedules;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DNA_SERVICES.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FeeScheduleController : ControllerBase
{
    private readonly ILogger<FeeScheduleController> _logger;

    private readonly IFeeScheduleService _IFeeScheduleService;
    readonly IConfiguration _configuration;

    public FeeScheduleController(ILogger<FeeScheduleController> logger,
        IFeeScheduleService feeScheduleService, IConfiguration configuration)
    {
        _logger = logger;
        _IFeeScheduleService = feeScheduleService;
        _configuration = configuration;
    }

    [Route("get")]
    [HttpPost]
    public async Task<IActionResult> Get(FeeScheduleInput feeScheduleInput)
    {
        if (ModelState.IsValid)
        {
            Log.Information("+GetData");
            var response = await _IFeeScheduleService.GetData(feeScheduleInput);
            Log.Information("-GetData");
            return Ok(response);
        }
        else
            return BadRequest();
    }

    [Route("update")]
    [HttpPost]
    public async Task<IActionResult> Update(FeeScheduleInput feeScheduleInput)
    {
        if (ModelState.IsValid)
        {
            Log.Information("+GetData");
            var response = await _IFeeScheduleService.update(feeScheduleInput);
            Log.Information("-GetData");
            return Ok(response);

        }
        else
            return BadRequest();
    }
}

