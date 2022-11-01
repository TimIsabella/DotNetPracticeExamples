using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNetPracticeExamples.Models.Composites
{
	[Keyless]
	public class AlbumDistributorComposite
	{
		public int AlbumId { get; set; }

		public int DistributorId { get; set; }
	}
}
