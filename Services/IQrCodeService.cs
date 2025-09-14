namespace IvyQrCodeGenerator.Services;

/// <summary>
/// Interface for QR code generation service
/// </summary>
public interface IQrCodeService
{
    /// <summary>
    /// Generates a QR code as a base64 encoded string
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    /// <returns>Base64 encoded QR code image</returns>
    string GenerateQrCodeAsBase64(string text, int pixelsPerModule = 4);

    /// <summary>
    /// Generates a QR code as a byte array
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    /// <returns>QR code image as byte array</returns>
    byte[] GenerateQrCodeAsBytes(string text, int pixelsPerModule = 4);

    /// <summary>
    /// Generates a QR code and saves it to a file
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="filePath">Path where to save the QR code image</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    void GenerateQrCodeToFile(string text, string filePath, int pixelsPerModule = 4);
}
