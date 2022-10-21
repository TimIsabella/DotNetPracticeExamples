using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models
{
	public class Song
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Language' field cannot be empty.")]
		public string Language { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Duration' field cannot be empty.")]
		public string Duration { get; set; }

		//'IFormFile' is not a database table type
		//-'NotMapped' decoration excludes mapping of the below to the table
		[NotMapped]
		public IFormFile Image { get; set; }

		public string ImageUrl { get; set; }
	}
}
