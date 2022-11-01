using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Composites
{
	[Keyless]
	public class AlbumFormatComposite
	{
		public int AlbumId { get; set; }

		public int FormatId { get; set; }
	}
}
