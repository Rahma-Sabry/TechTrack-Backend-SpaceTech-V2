using Microsoft.AspNetCore.Http;

namespace TechTrack.Domain.Interfaces.IService
{
    /// <summary>
    /// Service for managing image uploads and deletions in Cloudinary
    /// </summary>
    public interface ICloudinaryService
    {
        /// <summary>
        /// Uploads an image file to Cloudinary
        /// </summary>
        /// <param name="file">The image file to upload</param>
        /// <param name="folder">The Cloudinary folder to store the image (default: "categories")</param>
        /// <returns>The secure URL of the uploaded image</returns>
        /// <exception cref="ArgumentException">Thrown when file is invalid or exceeds size limit</exception>
        /// <exception cref="Exception">Thrown when Cloudinary upload fails</exception>
        Task<string> UploadImageAsync(IFormFile file, string folder = "categories");

        /// <summary>
        /// Deletes an image from Cloudinary by its public ID
        /// </summary>
        /// <param name="publicId">The public ID of the image to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        Task<bool> DeleteImageAsync(string publicId);

        /// <summary>
        /// Extracts the public ID from a Cloudinary image URL
        /// </summary>
        /// <param name="imageUrl">The full Cloudinary image URL</param>
        /// <returns>The public ID, or null if extraction fails</returns>
        string? ExtractPublicIdFromUrl(string imageUrl);
    }
}
