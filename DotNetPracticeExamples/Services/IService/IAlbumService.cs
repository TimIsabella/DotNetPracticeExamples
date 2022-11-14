using DotNetPracticeExamples.Models;
using System.Collections;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Services.IService
{
	public interface IAlbumService
	{
		IEnumerable GetAllAlbums();
		IEnumerable GetAllSongsOfAlbum();
		IEnumerable GetAllAlbumsWithTotalDuration();
		IEnumerable GetAllAlbumsWithAverageRating();
		IEnumerable GetAllAlbumsWithFormats();
		IEnumerable GetAllAlbumsWithFormatsAndDistributors();
	}
}