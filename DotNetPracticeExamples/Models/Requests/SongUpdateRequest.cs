using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models.Requests
{
	public class SongUpdateRequest
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Language' field cannot be empty.")]
		public string Language { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Duration' field cannot be empty.")]
		public string Duration { get; set; }
	}
}
