using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class AlbumFormatCompositeData
	{
		public static List<AlbumFormatComposite> Data = new List<AlbumFormatComposite>
		{ 
			//Album 1
			new AlbumFormatComposite
			{ 
				AlbumId = 1,
				FormatId = 1
			},

			new AlbumFormatComposite
			{
				AlbumId = 1,
				FormatId = 2
			},

			//Album 2
			new AlbumFormatComposite
			{
				AlbumId = 2,
				FormatId = 2
			},

			new AlbumFormatComposite
			{
				AlbumId = 2,
				FormatId = 3
			},

			new AlbumFormatComposite
			{
				AlbumId = 2,
				FormatId = 3
			},

			//Album 3
			new AlbumFormatComposite
			{
				AlbumId = 3,
				FormatId = 1
			},

			new AlbumFormatComposite
			{
				AlbumId = 3,
				FormatId = 2
			},

			new AlbumFormatComposite
			{
				AlbumId = 3,
				FormatId = 3
			},

			new AlbumFormatComposite
			{
				AlbumId = 3,
				FormatId = 4
			}
		};
	}
}
