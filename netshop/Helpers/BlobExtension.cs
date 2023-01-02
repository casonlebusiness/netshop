using Azure.Storage.Blobs;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.DependencyInjection;
using netshop.Models;

namespace netshop.Helpers
{
  public static class BlobExtension
  {
    public static string GenerateBlobUrl(string blobPath)
    {
      return blobPath != null ? $"https://netshopdev.blob.core.windows.net/{blobPath}" : "";
    }


    public static async Task<UploadResult> UploadImage(IFormFile file, string containerName)
    {
      string systemFileName = file.FileName;
      string blobstorageconnection = AppSettingsProvider.StorageAccountConnectionString;
      CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
      CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
      CloudBlobContainer container = blobClient.GetContainerReference(containerName);
      CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
      await using (var data = file.OpenReadStream())
      {
        await blockBlob.UploadFromStreamAsync(data);
      }
      return new UploadResult
        {
          filePath = $"images/{systemFileName}",
          status = CommonStatus.SUCCESS
        };
    }
  }
}
