using HttpClientFor.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFor.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IMyWorkingWebService myWorkingWebService;
    private readonly IMyFailingWebService myFailingWebService;
    private readonly ILogger<TestController> _logger;

    public TestController(IMyWorkingWebService myWebService, IMyFailingWebService myFailingWebService, ILogger<TestController> logger)
    {
        this.myWorkingWebService = myWebService;
        this.myFailingWebService = myFailingWebService;
        _logger = logger;
    }

    [HttpGet("Working")]
    public IActionResult GetWorking()
    {
        string httpClientBaseAddress = myWorkingWebService.TellMeBaseAddress();
        return Ok(httpClientBaseAddress);
    }

    [HttpGet("Failing")]
    public IActionResult GetFailing()
    {
        string httpClientBaseAddress = myFailingWebService.TellMeBaseAddress();
        return Ok(httpClientBaseAddress);
    }
}
