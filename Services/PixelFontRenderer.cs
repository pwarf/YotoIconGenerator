namespace YotoIconGenerator.Services;

/// <summary>
/// Renders text onto a 16x16 RGBA pixel buffer using the 3x5 pixel font.
/// </summary>
public static class PixelFontRenderer
{
    private const int Size = 16;
    private const int BytesPerPixel = 4; // RGBA
    private const int GlyphHeight = 5;
    private const int LineGap = 2;
    private const int CharGap = 1;

    /// <summary>
    /// Measures the pixel width of a string using the 3x5 font.
    /// </summary>
    public static int MeasureText(string text)
    {
        int width = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (i > 0) width += CharGap;
            width += GlyphData.GetGlyphWidth(text[i]);
        }
        return width;
    }

    /// <summary>
    /// Renders a 16x16 icon with line1 (label) on top and line2 (track number) below,
    /// both centered. Returns raw RGBA byte array (16*16*4 = 1024 bytes).
    /// </summary>
    public static byte[] RenderIcon(string line1, string line2, byte r, byte g, byte b)
    {
        var pixels = new byte[Size * Size * BytesPerPixel]; // initialized to 0 = fully transparent

        int line1Width = MeasureText(line1);
        int line2Width = MeasureText(line2);

        int line1X = (Size - line1Width) / 2;
        int line2X = (Size - line2Width) / 2;

        int blockHeight = GlyphHeight + LineGap + GlyphHeight; // 5 + 2 + 5 = 12
        int topY = (Size - blockHeight) / 2;
        int line1Y = topY;
        int line2Y = topY + GlyphHeight + LineGap;

        DrawText(pixels, line1, line1X, line1Y, r, g, b);
        DrawText(pixels, line2, line2X, line2Y, r, g, b);

        return pixels;
    }

    private static void DrawText(byte[] pixels, string text, int startX, int startY, byte r, byte g, byte b)
    {
        int cursorX = startX;
        foreach (char c in text)
        {
            if (!GlyphData.Glyphs.TryGetValue(c, out var glyph))
                continue;

            int rows = glyph.GetLength(0);
            int cols = glyph.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (glyph[row, col])
                    {
                        int px = cursorX + col;
                        int py = startY + row;
                        if (px >= 0 && px < Size && py >= 0 && py < Size)
                        {
                            int offset = (py * Size + px) * BytesPerPixel;
                            pixels[offset]     = r;
                            pixels[offset + 1] = g;
                            pixels[offset + 2] = b;
                            pixels[offset + 3] = 255; // fully opaque
                        }
                    }
                }
            }

            cursorX += cols + CharGap;
        }
    }
}
