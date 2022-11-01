using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Composites
{
	[Keyless]
	public class SongFormatComposite
	{
		public int SongId { get; set; }

		public int FormatId { get; set; }
	}
}
