using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Bridges
{
	public class SongFormatBridge
	{
		[Required]
		[Key]
		public int SongId { get; set; }

		[Required]
		[Key]
		public int FormatId { get; set; }
	}
}
