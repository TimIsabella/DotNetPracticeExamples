using DotNetPracticeExamples.Models;
using System.Collections;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{ 
	public interface IAlbumRepository
	{
		List<Album> GetAllAlbums();
		IEnumerable GetAllAlbumsWithAverageRating();
		IEnumerable GetAllAlbumsWithFormats();
		IEnumerable GetAllAlbumsWithFormatsAndDistributors();
		IEnumerable GetAllAlbumsWithTotalDuration();
		IEnumerable GetAllSongsOfAlbum();
	}
}
