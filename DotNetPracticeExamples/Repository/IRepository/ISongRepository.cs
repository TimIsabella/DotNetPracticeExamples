using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{
	public interface ISongRepository
	{
		List<Song> GetAllSongs();
		int Post(Song song);
		int DeleteById(int id);
	}
}