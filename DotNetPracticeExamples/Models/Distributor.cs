using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models
{
	public class Distributor
	{
		public int? Id { get; set; }

		[Required(ErrorMessage = "Input Error: The 'Name' field cannot be empty.")]
		public string Name { get; set; }

		public string? Url { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? Address { get; set; }

		public int? ZipCode { get; set; }
	}
}
