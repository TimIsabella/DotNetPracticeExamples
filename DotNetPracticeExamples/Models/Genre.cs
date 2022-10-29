namespace DotNetPracticeExamples.Models
{
	public class Genre
	{
		public int? Id { get; set; } //Adding '?' makes it readonly and not required for input
		public string GenreType { get; set; }
		public int Rating { get; set; }
	}
}
