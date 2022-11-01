using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models.Composites
{
	public class AlbumDistributorComposite
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AlbumId { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DistributorId { get; set; }
	}
}
