using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DotNetPracticeExamples.Models
{
	public class Album
	{
		public int? Id { get; set; } //Adding '?' makes it readonly and not required for input

		[Required(ErrorMessage = "Input Error: The 'Title' field cannot be empty.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Genre' field cannot be empty.")]
		public string Genre { get; set; }

		[Required(ErrorMessage = "Input Error: The 'GenreId' field cannot be empty.")]
		public int GenreId { get; set; }

		public string? CoverArtUrl { get; set; }

		public int? StatusId { get; set; }

		public bool? ForSale { get; set; }
	}
}
