using ZXing;
using ZXing.Common;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


if (args.Length == 0)
{
    Console.WriteLine("Usage: barcoder <text-to-encode>");
    return;
}

string textToEncode = args[0];

var writer = new BarcodeWriterPixelData
{
    Format = BarcodeFormat.CODE_128,
    Options = new EncodingOptions
    {
        Width = 300,
        Height = 100,
        Margin = 10
    }
};

var pixelData = writer.Write(textToEncode);

using var image = Image.LoadPixelData<Rgba32>(
    pixelData.Pixels,
    pixelData.Width,
    pixelData.Height);

await image.SaveAsPngAsync("barcode.png");

Console.WriteLine("Barcode saved.");
