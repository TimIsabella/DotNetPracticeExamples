using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models.Composites
{
	public class SongFormatComposite
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SongId { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int FormatId { get; set; }
	}
}
