using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Bridges
{
	public class AlbumFormatBridge
	{
		[Required]
		[Key]
		public int AlbumId { get; set; }

		[Required]
		[Key]
		public int FormatId { get; set; }
	}
}
