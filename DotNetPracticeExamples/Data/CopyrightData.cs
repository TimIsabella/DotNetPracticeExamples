using DotNetPracticeExamples.Models;
using System;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class CopyrightData
	{
		public static List<Copyright> Data = new List<Copyright> 
		{
			new Copyright
			{
				Id = 1,
				Type = "Licensing",
				Description = "A license is an agreement between a copyright holder and a user that allows the user to use the work in a way that would otherwise be infringing."
			},

			new Copyright
			{
				Id = 2,
				Type = "Fair Use",
				Description = "Fair Use allows for the use of copyrighted material without permission from the copyright holder for the purpose of criticism, commentary, news reporting, teaching, scholarship, or research."
			},
			new Copyright
			{
				Id = 3,
				Type = "Derivative Works",
				Description = "Derivative works are based on one or more preexisting works, such as a book, article, musical composition, or photograph."
			},
			new Copyright
			{
				Id = 4,
				Type = "Orphaned Works",
				Description = "Orphaned works are those whose copyright owners are unknown or cannot be located. These works may be used freely under certain circumstances."
			},
			new Copyright
			{
				Id = 5,
				Type = "Public Domain",
				Description = "Public domain includes works that are public which means that they are not protected by copyright and can be used by anyone."
			}
		};
	}
}
