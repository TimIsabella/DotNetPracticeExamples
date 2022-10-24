﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models
{
	public class Song
	{
		public int? Id { get; set; } //Adding '?' makes it readonly and not required for input

		[Required(ErrorMessage = "Input Error: The 'Artist' field cannot be empty.")]
		public string Artist { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Title' field cannot be empty.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Language' field cannot be empty.")]
		public string Genre { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Duration' field cannot be empty.")]
		public TimeSpan Duration { get; set; }

		public int Rating { get; set; }

		public int StatusId { get; set; }

		public bool ForSale { get; set; }
	}
}
