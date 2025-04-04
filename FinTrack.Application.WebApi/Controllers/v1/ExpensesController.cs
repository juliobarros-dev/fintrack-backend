using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.Application.WebApi.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[Consumes("application/json")]
[Route("v{version:apiVersion}/[controller]")]
public class ExpensesController : ControllerBase
{
	[HttpGet]
	public IActionResult Get()
	{
		return Ok("Controller is working!!");
	}
}