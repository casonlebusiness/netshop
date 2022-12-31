using Microsoft.Extensions.DependencyInjection;

namespace netshop.Helpers
{
    public static class BlobExtension
    {
        public static string GenerateBlobUrl(string blobPath)
        {
            return $"https://netshopdev.blob.core.windows.net/{blobPath}";
        }
    }
}
