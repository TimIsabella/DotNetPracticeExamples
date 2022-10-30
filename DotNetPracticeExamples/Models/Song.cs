using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DotNetPracticeExamples.Models
{
	public class Song
	{
		public int? Id { get; set; } //Adding '?' makes it readonly and not required for input

		[Required(ErrorMessage = "Input Error: The 'Artist' field cannot be empty.")]
		public string Artist { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Title' field cannot be empty.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Genre' field cannot be empty.")]
		public string Genre { get; set; }

		[Required(ErrorMessage = "Input Error: The 'GenreId' field cannot be empty.")]
		public int GenreId { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Duration' field cannot be empty.")]
		public TimeSpan Duration { get; set; }

		public int? AlbumId { get; set; }

		public int? Rating { get; set; }

		public int? CopyrightId { get; set; }

		public bool? ForSale { get; set; }
	}
}
