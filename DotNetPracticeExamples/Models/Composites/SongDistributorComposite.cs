using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetPracticeExamples.Models.Composites
{
	public class SongDistributorComposite
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SongId { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DistributorId { get; set; }
	}
}
