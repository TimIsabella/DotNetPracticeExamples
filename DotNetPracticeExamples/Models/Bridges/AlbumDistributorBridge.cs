using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Bridges
{
	public class AlbumDistributorBridge
	{
		[Required]
		[Key]
		public int AlbumId { get; set; }

		[Required]
		[Key]
		public int DistributorId { get; set; }
	}
}
