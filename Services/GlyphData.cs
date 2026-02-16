namespace YotoIconGenerator.Services;

/// <summary>
/// 3x5 pixel font glyph definitions for A-Z and 0-9.
/// Each glyph is a bool[rows, cols] where rows=5, cols=1-3.
/// Designed for maximum readability at 16x16 icon resolution.
/// </summary>
public static class GlyphData
{
    public static readonly Dictionary<char, bool[,]> Glyphs = new()
    {
        // === LETTERS ===

        ['A'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { true,  true,  true  },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['B'] = new bool[,] {
            { true,  true,  false },
            { true,  false, true  },
            { true,  true,  false },
            { true,  false, true  },
            { true,  true,  false },
        },
        ['C'] = new bool[,] {
            { false, true,  true  },
            { true,  false, false },
            { true,  false, false },
            { true,  false, false },
            { false, true,  true  },
        },
        ['D'] = new bool[,] {
            { true,  true,  false },
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  false },
        },
        ['E'] = new bool[,] {
            { true,  true,  true  },
            { true,  false, false },
            { true,  true,  false },
            { true,  false, false },
            { true,  true,  true  },
        },
        ['F'] = new bool[,] {
            { true,  true,  true  },
            { true,  false, false },
            { true,  true,  false },
            { true,  false, false },
            { true,  false, false },
        },
        ['G'] = new bool[,] {
            { false, true,  true  },
            { true,  false, false },
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  true  },
        },
        ['H'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  true  },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['I'] = new bool[,] {
            { true,  true,  true  },
            { false, true,  false },
            { false, true,  false },
            { false, true,  false },
            { true,  true,  true  },
        },
        ['J'] = new bool[,] {
            { false, false, true  },
            { false, false, true  },
            { false, false, true  },
            { true,  false, true  },
            { false, true,  false },
        },
        ['K'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  false },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['L'] = new bool[,] {
            { true,  false, false },
            { true,  false, false },
            { true,  false, false },
            { true,  false, false },
            { true,  true,  true  },
        },
        ['M'] = new bool[,] {
            { true,  false, true  },
            { true,  true,  true  },
            { true,  true,  true  },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['N'] = new bool[,] {
            { true,  false, true  },
            { true,  true,  true  },
            { true,  true,  true  },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['O'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
        },
        ['P'] = new bool[,] {
            { true,  true,  false },
            { true,  false, true  },
            { true,  true,  false },
            { true,  false, false },
            { true,  false, false },
        },
        ['Q'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  false },
            { false, true,  true  },
        },
        ['R'] = new bool[,] {
            { true,  true,  false },
            { true,  false, true  },
            { true,  true,  false },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['S'] = new bool[,] {
            { false, true,  true  },
            { true,  false, false },
            { false, true,  false },
            { false, false, true  },
            { true,  true,  false },
        },
        ['T'] = new bool[,] {
            { true,  true,  true  },
            { false, true,  false },
            { false, true,  false },
            { false, true,  false },
            { false, true,  false },
        },
        ['U'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
        },
        ['V'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
        },
        ['W'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  true  },
            { true,  true,  true  },
            { true,  false, true  },
        },
        ['X'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
            { true,  false, true  },
            { true,  false, true  },
        },
        ['Y'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
            { false, true,  false },
            { false, true,  false },
        },
        ['Z'] = new bool[,] {
            { true,  true,  true  },
            { false, false, true  },
            { false, true,  false },
            { true,  false, false },
            { true,  true,  true  },
        },

        // === DIGITS ===

        ['0'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { true,  false, true  },
            { true,  false, true  },
            { false, true,  false },
        },
        ['1'] = new bool[,] {
            { false, true },
            { true,  true },
            { false, true },
            { false, true },
            { true,  true },
        },
        ['2'] = new bool[,] {
            { true,  true,  false },
            { false, false, true  },
            { false, true,  false },
            { true,  false, false },
            { true,  true,  true  },
        },
        ['3'] = new bool[,] {
            { true,  true,  false },
            { false, false, true  },
            { true,  true,  false },
            { false, false, true  },
            { true,  true,  false },
        },
        ['4'] = new bool[,] {
            { true,  false, true  },
            { true,  false, true  },
            { true,  true,  true  },
            { false, false, true  },
            { false, false, true  },
        },
        ['5'] = new bool[,] {
            { true,  true,  true  },
            { true,  false, false },
            { true,  true,  false },
            { false, false, true  },
            { true,  true,  false },
        },
        ['6'] = new bool[,] {
            { false, true,  true  },
            { true,  false, false },
            { true,  true,  false },
            { true,  false, true  },
            { false, true,  false },
        },
        ['7'] = new bool[,] {
            { true,  true,  true  },
            { false, false, true  },
            { false, true,  false },
            { false, true,  false },
            { false, true,  false },
        },
        ['8'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { false, true,  false },
            { true,  false, true  },
            { false, true,  false },
        },
        ['9'] = new bool[,] {
            { false, true,  false },
            { true,  false, true  },
            { false, true,  true  },
            { false, false, true  },
            { true,  true,  false },
        },

        // === SPECIAL ===

        [' '] = new bool[,] {
            { false },
            { false },
            { false },
            { false },
            { false },
        },
        ['-'] = new bool[,] {
            { false, false, false },
            { false, false, false },
            { true,  true,  true  },
            { false, false, false },
            { false, false, false },
        },
        ['.'] = new bool[,] {
            { false },
            { false },
            { false },
            { false },
            { true  },
        },
        [','] = new bool[,] {
            { false, false },
            { false, false },
            { false, false },
            { false, true  },
            { true,  false },
        },
        ['\''] = new bool[,] {
            { true  },
            { true  },
            { false },
            { false },
            { false },
        },
        ['+'] = new bool[,] {
            { false, false, false },
            { false, true,  false },
            { true,  true,  true  },
            { false, true,  false },
            { false, false, false },
        },
        ['!'] = new bool[,] {
            { true },
            { true },
            { true },
            { false },
            { true },
        },
    };

    public static int GetGlyphWidth(char c)
    {
        if (Glyphs.TryGetValue(c, out var glyph))
            return glyph.GetLength(1);
        return 0;
    }

    public static bool IsSupported(char c) => Glyphs.ContainsKey(c);
}
