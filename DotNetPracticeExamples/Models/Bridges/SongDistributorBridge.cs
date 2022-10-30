using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Bridges
{
	public class SongDistributorBridge
	{
		[Required]
		[Key]
		public int SongId { get; set; }

		[Required]
		[Key]
		public int DistributorId { get; set; }
	}
}
