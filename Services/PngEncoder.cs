using System.IO.Compression;

namespace YotoIconGenerator.Services;

/// <summary>
/// Minimal PNG encoder for 16x16 RGBA images.
/// Produces valid PNG files from raw RGBA pixel data with no external dependencies.
/// </summary>
public static class PngEncoder
{
    private static readonly byte[] PngSignature = { 137, 80, 78, 71, 13, 10, 26, 10 };

    private static readonly uint[] Crc32Table = BuildCrc32Table();

    public static byte[] Encode(byte[] rgba, int width, int height)
    {
        using var output = new MemoryStream();

        // PNG signature
        output.Write(PngSignature);

        // IHDR chunk
        var ihdr = new byte[13];
        WriteInt32BigEndian(ihdr, 0, width);
        WriteInt32BigEndian(ihdr, 4, height);
        ihdr[8] = 8;  // bit depth
        ihdr[9] = 6;  // color type: RGBA
        ihdr[10] = 0; // compression method
        ihdr[11] = 0; // filter method
        ihdr[12] = 0; // interlace method
        WriteChunk(output, "IHDR", ihdr);

        // IDAT chunk - build raw image data with filter bytes, then zlib-compress
        var rawData = BuildFilteredImageData(rgba, width, height);
        var compressedData = ZlibCompress(rawData);
        WriteChunk(output, "IDAT", compressedData);

        // IEND chunk
        WriteChunk(output, "IEND", Array.Empty<byte>());

        return output.ToArray();
    }

    private static byte[] BuildFilteredImageData(byte[] rgba, int width, int height)
    {
        int rowBytes = width * 4;
        var data = new byte[height * (1 + rowBytes)];
        int pos = 0;

        for (int y = 0; y < height; y++)
        {
            data[pos++] = 0; // filter type: None
            Array.Copy(rgba, y * rowBytes, data, pos, rowBytes);
            pos += rowBytes;
        }

        return data;
    }

    private static byte[] ZlibCompress(byte[] data)
    {
        using var output = new MemoryStream();

        // Zlib header (CM=8 deflate, CINFO=7 window, FCHECK makes it divisible by 31)
        output.WriteByte(0x78);
        output.WriteByte(0x01);

        // Deflate-compressed data
        using (var deflate = new DeflateStream(output, CompressionLevel.Optimal, leaveOpen: true))
        {
            deflate.Write(data, 0, data.Length);
        }

        // Adler-32 checksum of uncompressed data
        uint adler = ComputeAdler32(data);
        output.WriteByte((byte)(adler >> 24));
        output.WriteByte((byte)(adler >> 16));
        output.WriteByte((byte)(adler >> 8));
        output.WriteByte((byte)(adler));

        return output.ToArray();
    }

    private static uint ComputeAdler32(byte[] data)
    {
        uint a = 1, b = 0;
        const uint mod = 65521;

        for (int i = 0; i < data.Length; i++)
        {
            a = (a + data[i]) % mod;
            b = (b + a) % mod;
        }

        return (b << 16) | a;
    }

    private static void WriteChunk(MemoryStream output, string type, byte[] data)
    {
        // Length (4 bytes, big-endian)
        var lengthBytes = new byte[4];
        WriteInt32BigEndian(lengthBytes, 0, data.Length);
        output.Write(lengthBytes);

        // Type (4 ASCII bytes)
        var typeBytes = new byte[4];
        for (int i = 0; i < 4; i++)
            typeBytes[i] = (byte)type[i];
        output.Write(typeBytes);

        // Data
        output.Write(data);

        // CRC32 over type + data
        uint crc = ComputeCrc32(typeBytes, data);
        var crcBytes = new byte[4];
        WriteInt32BigEndian(crcBytes, 0, (int)crc);
        output.Write(crcBytes);
    }

    private static uint ComputeCrc32(byte[] typeBytes, byte[] data)
    {
        uint crc = 0xFFFFFFFF;

        for (int i = 0; i < typeBytes.Length; i++)
            crc = Crc32Table[(crc ^ typeBytes[i]) & 0xFF] ^ (crc >> 8);

        for (int i = 0; i < data.Length; i++)
            crc = Crc32Table[(crc ^ data[i]) & 0xFF] ^ (crc >> 8);

        return crc ^ 0xFFFFFFFF;
    }

    private static uint[] BuildCrc32Table()
    {
        var table = new uint[256];
        for (uint i = 0; i < 256; i++)
        {
            uint c = i;
            for (int j = 0; j < 8; j++)
            {
                if ((c & 1) != 0)
                    c = 0xEDB88320 ^ (c >> 1);
                else
                    c >>= 1;
            }
            table[i] = c;
        }
        return table;
    }

    private static void WriteInt32BigEndian(byte[] buffer, int offset, int value)
    {
        buffer[offset]     = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value);
    }
}
