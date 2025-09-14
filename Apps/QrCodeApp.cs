using IvyQrCodeGenerator.Services;

namespace IvyQrCodeGenerator.Apps;

[App(icon: Icons.QrCode, title: "QR Code Generator")]
public class QrCodeApp : ViewBase
{
    public override object? Build()
    {
        var textState = this.UseState<string>("Hello, World!");
        var qrCodeService = this.UseService<IQrCodeService>();
        var qrCodeBase64 = this.UseMemo(() =>
        {
            if (string.IsNullOrEmpty(textState.Value))
                return string.Empty;

            try
            {
                return qrCodeService.GenerateQrCodeAsBase64(textState.Value, 8);
            }
            catch
            {
                return string.Empty;
            }
        }, [textState.Value]);

        return Layout.Center()
               | (new Card(
                   Layout.Vertical().Gap(6).Padding(2)
                   | Text.H2("QR Code Generator")
                   | Text.Block("Enter text below to generate a QR code:")
                   | textState.ToInput(placeholder: "Enter text to encode...")
                   | new Separator()
                   | (string.IsNullOrEmpty(qrCodeBase64)
                       ? Text.Block("Enter some text to generate a QR code")
                       : Text.Html($"<img src=\"data:image/png;base64,{qrCodeBase64}\" width=\"200\" height=\"200\" style=\"display: block; margin: 0 auto;\" />"))
                 )
                 .Width(Size.Units(120).Max(500)));
    }
}
