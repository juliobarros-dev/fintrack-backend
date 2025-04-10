using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FinTrack.Domain.Models;

namespace FinTrack.Application.WebApi.Dtos;

public class BankDto
{
	[JsonPropertyName("id")]
	public int? Id { get; set; }
	
	[Required]
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	
	[Required]
	[JsonPropertyName("code")]
	public int Code { get; set; }

	
	public (bool isSuccess, List<string> errors) Validate()
	{
		var errors = new List<string>();
		var isSuccess = true;

		if (string.IsNullOrWhiteSpace(Name) is false) return (isSuccess, errors);
		
		errors.Add("Name cannot be null or empty.");
		isSuccess = false;

		return (isSuccess, errors);
	}

	public Bank ToDomain()
	{
		return new Bank()
		{
			Id = Id,
			Name = Name,
			Code = Code,
		};
	}
}