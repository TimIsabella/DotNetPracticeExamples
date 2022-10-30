using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class AlbumData
	{
		public static List<Album> Data = new List<Album>
		{
			new Album
			{
				Id = 1,
				Title = "Psytrance Album",
				Genre = "Psytrance",
				GenreId = 1,
				CoverArtUrl = "https://www.website.com/coverart.jpg",
				StatusId = 1,
				ForSale = true,
				//Formats = new int[] { 1, 2 },
			},

			new Album
			{
				Id = 2,
				Title = "Popular Album",
				Genre = "Pop",
				GenreId = 4,
				CoverArtUrl = "https://www.popwebsite.com/coverart.jpg",
				StatusId = 2,
				ForSale = false,
				//Formats = new int[] { 2, 3, 4 }
			},

			new Album
			{
				Id = 3,
				Title = "Mix Album",
				Genre = "Various",
				GenreId = 10,
				CoverArtUrl = "https://www.mixalbum.com/coverart.jpg",
				StatusId = 3,
				ForSale = true,
				//Formats = new int[] { 1, 2, 3, 4 },
			}
		};
	}
}
