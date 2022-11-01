using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models.Composites
{
	public class AlbumFormatComposite
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AlbumId { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int FormatId { get; set; }
	}
}
