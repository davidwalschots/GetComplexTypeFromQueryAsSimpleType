using Microsoft.AspNetCore.Mvc;

namespace Api;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    [HttpPost("basic")]
    public IActionResult GetWithNoCustomization(Input wrapper) => Ok(wrapper.Prop.Value);

    [HttpGet("from-query")]
    public IActionResult GetWithFromQuery([FromQuery] SomeWrapperType wrapper) => Ok(wrapper.Value);
}

public class Input
{
    public SomeWrapperType Prop { get; set; }
}
