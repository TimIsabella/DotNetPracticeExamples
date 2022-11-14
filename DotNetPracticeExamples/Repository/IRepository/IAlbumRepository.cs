using System.Collections;

namespace DotNetPracticeExamples.Repository.IRepository
{ 
	public interface IAlbumRepository
	{
		IEnumerable GetAllAlbums();
		IEnumerable GetAllAlbumsWithAverageRating();
		IEnumerable GetAllAlbumsWithFormats();
		IEnumerable GetAllAlbumsWithFormatsAndDistributors();
		IEnumerable GetAllAlbumsWithTotalDuration();
		IEnumerable GetAllSongsOfAlbum();
	}
}
