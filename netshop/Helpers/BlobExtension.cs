using Microsoft.Extensions.DependencyInjection;

namespace netshop.Helpers
{
    public static class BlobExtension
    {
        public static string GenerateBlobUrl(string blobPath)
        {
            return blobPath != null ? $"https://netshopdev.blob.core.windows.net/{blobPath}" : ""; 
        }
    }
}
