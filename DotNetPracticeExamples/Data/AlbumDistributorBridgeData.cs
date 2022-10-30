using DotNetPracticeExamples.Models.Bridges;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class AlbumDistributorBridgeData
	{
		public static List<AlbumDistributorBridge> Data = new List<AlbumDistributorBridge>
		{
			//Album 1
			new AlbumDistributorBridge
			{
				AlbumId = 1,
				DistributorId = 2
			},
			
			new AlbumDistributorBridge
			{
				AlbumId = 1,
				DistributorId = 3
			},
			
			new AlbumDistributorBridge
			{
				AlbumId = 1,
				DistributorId = 4
			},

			new AlbumDistributorBridge
			{
				AlbumId = 1,
				DistributorId = 5
			},

			//Album 2
			new AlbumDistributorBridge
			{
				AlbumId = 2,
				DistributorId = 2
			},

			new AlbumDistributorBridge
			{
				AlbumId = 2,
				DistributorId = 3
			},

			new AlbumDistributorBridge
			{
				AlbumId = 2,
				DistributorId = 4
			},

			//Album 3
			new AlbumDistributorBridge
			{
				AlbumId = 3,
				DistributorId = 1
			},

			new AlbumDistributorBridge
			{
				AlbumId = 3,
				DistributorId = 4
			},
		};
	}
}
