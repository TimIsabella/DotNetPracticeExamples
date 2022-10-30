using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class GenreData
	{
		public static List<Genre> Data = new List<Genre>
		{
			new Genre
			{
				Id = 1,
				GenreType = "Psytrance",
				Rating = 11
			},

			new Genre
			{
				Id = 2,
				GenreType = "Electronic",
				Rating = 22
			},

			new Genre
			{
				Id = 3,
				GenreType = "Pop Electronic",
				Rating = 33
			},

			new Genre
			{
				Id = 4,
				GenreType = "Pop",
				Rating = 44
			},

			new Genre
			{
				Id = 5,
				GenreType = "Disco",
				Rating = 55
			},

			new Genre
			{
				Id = 6,
				GenreType = "Pop Disco",
				Rating = 66
			},

			new Genre
			{
				Id = 7,
				GenreType = "Television OST",
				Rating = 77
			},

			new Genre
			{
				Id = 8,
				GenreType = "Ambient",
				Rating = 88
			},

			new Genre
			{
				Id = 9,
				GenreType = "Classic Electronic",
				Rating = 99
			},

			new Genre
			{
				Id = 10,
				GenreType = "Various",
				Rating = 11
			},

			new Genre
			{
				Id = 11,
				GenreType = "Other",
				Rating = 22
			}
		};
	}
}
