using DotNetPracticeExamples.Models;
using System.Collections;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Services.IService
{
	public interface ISongService
	{
		IEnumerable GetAllSongs();
		IEnumerable GetAllSongsByGenre();
		IEnumerable GetAllSongsJoinedWithAlbumName();
		IEnumerable GetSongsByDurationGreaterThan(int duration);
		IEnumerable GetSongsByGenre(string genre);
		IEnumerable GetSongsByRatingGreaterThan(int rating);
		IEnumerable GetSongsPagniated(int pageIndex, int pageSize);
		IEnumerable GetAllSongsWithDistributor();

		int Post(Song song);
		int DeleteById(int id);
	}
}