using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos;

public class BaseDto
{
	public int Id { get; set; }

	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public string Name { get; set; } = null!; // required

	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string? Description { get; set; } = null; // required

	public DateTime? UpdatedAt { get; set; } 
}