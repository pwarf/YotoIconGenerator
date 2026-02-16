using System.IO.Compression;

namespace YotoIconGenerator.Services;

/// <summary>
/// Orchestrates icon generation: single PNGs, preview data URIs, and ZIP bundles.
/// </summary>
public class IconGeneratorService
{
    private const int IconSize = 16;

    /// <summary>
    /// Generates a single 16x16 PNG icon for the given label and track number.
    /// </summary>
    public byte[] GenerateSinglePng(string label, int trackNumber, byte r, byte g, byte b)
    {
        string line1 = label.ToUpperInvariant();
        string line2 = trackNumber.ToString();
        var rgba = PixelFontRenderer.RenderIcon(line1, line2, r, g, b);
        return PngEncoder.Encode(rgba, IconSize, IconSize);
    }

    /// <summary>
    /// Generates a base64 data URI for previewing a single icon.
    /// </summary>
    public string GeneratePreviewDataUri(string label, int trackNumber, byte r, byte g, byte b)
    {
        var pngBytes = GenerateSinglePng(label, trackNumber, r, g, b);
        return "data:image/png;base64," + Convert.ToBase64String(pngBytes);
    }

    /// <summary>
    /// Generates a ZIP file containing all track icons (01.png through NN.png)
    /// inside a named folder.
    /// </summary>
    public byte[] GenerateZip(string label, int trackCount, string folderName, byte r, byte g, byte b)
    {
        using var memoryStream = new MemoryStream();

        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, leaveOpen: true))
        {
            for (int track = 1; track <= trackCount; track++)
            {
                var pngBytes = GenerateSinglePng(label, track, r, g, b);
                string entryName = $"{folderName}/{track:D2}.png";
                var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(pngBytes, 0, pngBytes.Length);
            }
        }

        return memoryStream.ToArray();
    }
}
