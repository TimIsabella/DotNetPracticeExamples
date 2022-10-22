using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DotNetPracticeExamples.Helpers
{
	public static class FileHelper
	{
		//Helper class to be used for any Azure file upload
		//- Uploads the file to Azure and returns the URI as a string
		//- 'IFormFile' (.NET extension of 'Http' class) -- Represents a file sent with the HttpRequest
		public static async Task<string> UploadImage(IFormFile file)
		{
			//Connection string from Azure 'storage account' in 'access keys'
			string connectionString = "DefaultEndpointsProtocol=https;AccountName=musicapistorage111;AccountKey=a/0FxEk+oayUGvdSUD8FIXdM9kizasTVIkXm3r5UiPf0XMaTA/VaMTeEpIYMGYXxF+eDFLb3IzXE+AStcLVlEg==;EndpointSuffix=core.windows.net";

			//Azure 'storage account' 'container' name
			string containerName = "songart";

			//Instantiates a new Azure 'blob' connection instance by using the above
			var blobContainerClient = new BlobContainerClient(connectionString, containerName);

			//Call '.GetBlobClient' from above instance to create a new 'blobClient' named as the song 'FileName'
			//- Client input from 'Image' is gotten from 'FromForm'
			//- Song model 'Image' is extended by 'IFormFile' which contains the 'FileName' property
			//- 'FileName' returns the file name from the 'Content-Disposition header'
			var blobClient = blobContainerClient.GetBlobClient(file.FileName);

			//Instantiate a new 'MemoryStream' object from 'System.IO'
			var memoryStream = new MemoryStream();

			//Copies song image to 'memoryStream'
			await file.CopyToAsync(memoryStream);

			//Reset 'stream' position to zero
			memoryStream.Position = 0;

			//Upload 'memoryStream' to Azure 'blobClient'
			await blobClient.UploadAsync(memoryStream);

			//Return image Uri from Azure 'blobClient'
			return blobClient.Uri.AbsoluteUri;
		}
	}
}
