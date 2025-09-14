using QRCoder;

namespace IvyQrCodeGenerator.Services;

/// <summary>
/// Service for generating QR codes using QRCoder library
/// </summary>
public class QrCodeService : IQrCodeService
{
    /// <summary>
    /// Generates a QR code as a base64 encoded string
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    /// <returns>Base64 encoded QR code image</returns>
    public string GenerateQrCodeAsBase64(string text, int pixelsPerModule = 4)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        var qrCodeBytes = qrCode.GetGraphic(pixelsPerModule);
        
        return Convert.ToBase64String(qrCodeBytes);
    }

    /// <summary>
    /// Generates a QR code as a byte array
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    /// <returns>QR code image as byte array</returns>
    public byte[] GenerateQrCodeAsBytes(string text, int pixelsPerModule = 4)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        
        return qrCode.GetGraphic(pixelsPerModule);
    }

    /// <summary>
    /// Generates a QR code and saves it to a file
    /// </summary>
    /// <param name="text">The text to encode in the QR code</param>
    /// <param name="filePath">Path where to save the QR code image</param>
    /// <param name="pixelsPerModule">Size of each module in pixels (default: 4)</param>
    public void GenerateQrCodeToFile(string text, string filePath, int pixelsPerModule = 4)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        var qrCodeBytes = qrCode.GetGraphic(pixelsPerModule);
        
        File.WriteAllBytes(filePath, qrCodeBytes);
    }
}
