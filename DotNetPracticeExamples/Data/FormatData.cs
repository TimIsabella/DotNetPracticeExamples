using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class FormatData
	{
		public static List<Format> Fdata = new List<Format>
		{
			new Format
			{
				Id = 1,
				Type = "Digital Download"
			},
			new Format
			{
				Id = 2,
				Type = "Compact Disc"
			},
			new Format
			{
				Id = 3,
				Type = "Cassette Tape"
			},
			new Format
			{
				Id = 4,
				Type = "Record"
			},
			new Format
			{
				Id = 5,
				Type = "Other"
			}
		};
	}
}
