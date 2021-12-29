using Microsoft.AspNetCore.Mvc;

namespace Api;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    
    [HttpGet("basic")]
    public IActionResult GetWithNoCustomization(SomeWrapperType wrapper)
        => Ok(wrapper.Value);

    [HttpGet("from-query")]
    public IActionResult GetWithFromQuery([FromQuery]SomeWrapperType wrapper)
        => Ok(wrapper.Value);
}