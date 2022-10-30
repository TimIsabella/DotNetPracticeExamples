using DotNetPracticeExamples.Models.Bridges;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class AlbumFormatBridgeData
	{
		public static List<AlbumFormatBridge> Data = new List<AlbumFormatBridge>
		{ 
			//Album 1
			new AlbumFormatBridge
			{ 
				AlbumId = 1,
				FormatId = 1
			},

			new AlbumFormatBridge
			{
				AlbumId = 1,
				FormatId = 2
			},

			//Album 2
			new AlbumFormatBridge
			{
				AlbumId = 2,
				FormatId = 2
			},

			new AlbumFormatBridge
			{
				AlbumId = 2,
				FormatId = 3
			},

			new AlbumFormatBridge
			{
				AlbumId = 2,
				FormatId = 3
			},

			//Album 3
			new AlbumFormatBridge
			{
				AlbumId = 3,
				FormatId = 1
			},

			new AlbumFormatBridge
			{
				AlbumId = 3,
				FormatId = 2
			},

			new AlbumFormatBridge
			{
				AlbumId = 3,
				FormatId = 3
			},

			new AlbumFormatBridge
			{
				AlbumId = 3,
				FormatId = 4
			},
		};
	}
}
