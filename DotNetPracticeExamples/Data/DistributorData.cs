using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class DistributorData
	{
		public static List<Distributor> Data = new List<Distributor>
		{
			new Distributor
			{
				Id = 1,
				Name = "Classic Records",
				City = "Classic City",
				State = "CA",
				Address = "123 Fake St",
				ZipCode = 90210
			},

			new Distributor
			{
				Id = 2,
				Name = "DigiMusic",
				Url = "https://www.digimusic.com",
				City = "Another City",
				State = "VA",
				Address = "PO Box 1234",
				ZipCode = 23723
			},

			new Distributor
			{
				Id = 3,
				Name = "Super Downloads",
				Url = "https://www.superdownloads.com"
			},

			new Distributor
			{
				Id = 4,
				Name = "Great Music Distro",
				Url = "https://www.GMD.com",
				City = "Las Vegas",
				State = "NV",
				Address = "123 Sunset Blvd.",
				ZipCode = 89123
			},

			new Distributor
			{
				Id = 5,
				Name = "Cheap Music Digital",
				Url = "https://www.CheapSongs.com"
			}
		};
	}
}
