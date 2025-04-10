using Asp.Versioning;
using FinTrack.Application.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.Application.WebApi.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[Consumes("application/json")]
[Route("v{version:apiVersion}/[controller]")]
public class BanksController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(500)]
	public IActionResult AddBank([FromBody] BankDto payload)
	{
		var errorsList = new List<string>();
		
		try
		{
			if (payload.Id is not null) errorsList.Add("To add a new bank, Id must be null. Use PUT to update");

			var validations = payload.Validate();
			
			if (validations.isSuccess is false) errorsList.AddRange(validations.errors);

			if (errorsList.Count > 0) return StatusCode(400, errorsList);
			
			return StatusCode(201);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new
			{
				error = "Something went wrong, please try again",
				details = ex.Message
			} );
		}
	}
	
	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	[ProducesResponseType(500)]
	public IActionResult GetBanks()
	{
		var errorsList = new List<string>();
		
		try
		{
			if (errorsList.Count > 0) return StatusCode(404, errorsList);
			
			return StatusCode(200);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new
			{
				error = "Something went wrong, please try again",
				details = ex.Message
			} );
		}
	}
}