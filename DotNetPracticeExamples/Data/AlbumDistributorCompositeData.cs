using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class AlbumDistributorCompositeData
	{
		public static List<AlbumDistributorComposite> Data = new List<AlbumDistributorComposite>
		{
			//Album 1
			new AlbumDistributorComposite
			{
				AlbumId = 1,
				DistributorId = 2
			},
			
			new AlbumDistributorComposite
			{
				AlbumId = 1,
				DistributorId = 3
			},
			
			new AlbumDistributorComposite
			{
				AlbumId = 1,
				DistributorId = 4
			},

			new AlbumDistributorComposite
			{
				AlbumId = 1,
				DistributorId = 5
			},

			//Album 2
			new AlbumDistributorComposite
			{
				AlbumId = 2,
				DistributorId = 2
			},

			new AlbumDistributorComposite
			{
				AlbumId = 2,
				DistributorId = 3
			},

			new AlbumDistributorComposite
			{
				AlbumId = 2,
				DistributorId = 4
			},

			//Album 3
			new AlbumDistributorComposite
			{
				AlbumId = 3,
				DistributorId = 1
			},

			new AlbumDistributorComposite
			{
				AlbumId = 3,
				DistributorId = 4
			}
		};
	}
}
