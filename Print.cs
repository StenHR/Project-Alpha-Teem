using System;
using System.Threading;
using System.Linq;

public static class Print
{
    public enum PrintStyle
    {
        Instant,
        TypeEffect
    }

    public enum ColorMode
    {
        Single,
        Rainbow,
        Gradient,
        Random,
        Blinking
    }

    // Default settings
    private const int DefaultTypeSpeed = 60;
    private static readonly Random _random = new Random();

    /// <summary>
    /// Prints dialog with multiple customization options
    /// </summary>
    /// <param name="dialog">Text to print</param>
    /// <param name="color">Base color for printing</param>
    /// <param name="style">Printing style (instant or type effect)</param>
    /// <param name="colorMode">Color application mode</param>
    /// <param name="typeSpeed">Speed of typing effect</param>
    /// <param name="addNewLine">Add new line after printing</param>
    public static void Dialog(
        string dialog, 
        ConsoleColor color = ConsoleColor.White, 
        PrintStyle style = PrintStyle.Instant,
        ColorMode colorMode = ColorMode.Single,
        int typeSpeed = DefaultTypeSpeed,
        bool addNewLine = true
    )
    {
        ConsoleColor[] colors = GetColorArray(dialog, color, colorMode);

        if (style == PrintStyle.Instant)
        {
            PrintInstant(dialog, colors, addNewLine);
        }
        else
        {
            PrintTypeEffect(dialog, colors, typeSpeed, addNewLine);
        }
    }

    private static void PrintInstant(string dialog, ConsoleColor[] colors, bool addNewLine)
    {
        for (int i = 0; i < dialog.Length; i++)
        {
            Console.ForegroundColor = colors[i];
            Console.Write(dialog[i]);
        }
        Console.ResetColor();
        if (addNewLine)
        {
            Console.WriteLine();
        }
    }

    private static void PrintTypeEffect(string dialog, ConsoleColor[] colors, int typeSpeed, bool addNewLine)
    {
        for (int i = 0; i < dialog.Length; i++)
        {
            Console.ForegroundColor = colors[i];
            Console.Write(dialog[i]);
            Thread.Sleep(typeSpeed);
        }
        Console.ResetColor();
        if (addNewLine)
        {
            Console.WriteLine();
        }
    }

    private static ConsoleColor[] GetColorArray(string dialog, ConsoleColor baseColor, ColorMode colorMode)
    {
        ConsoleColor[] colors = new ConsoleColor[dialog.Length];

        switch (colorMode)
        {
            case ColorMode.Single:
                Array.Fill(colors, baseColor);
                break;

            case ColorMode.Rainbow:
                ConsoleColor[] rainbowColors = new ConsoleColor[] 
                { 
                    ConsoleColor.Red, 
                    ConsoleColor.DarkYellow, 
                    ConsoleColor.Yellow, 
                    ConsoleColor.Green, 
                    ConsoleColor.Blue, 
                    ConsoleColor.Magenta, 
                    ConsoleColor.DarkMagenta 
                };
                for (int i = 0; i < dialog.Length; i++)
                {
                    colors[i] = rainbowColors[i % rainbowColors.Length];
                }
                break;

            case ColorMode.Random:
                ConsoleColor[] allColors = Enum.GetValues(typeof(ConsoleColor))
                    .Cast<ConsoleColor>()
                    .ToArray();
                for (int i = 0; i < dialog.Length; i++)
                {
                    colors[i] = allColors[_random.Next(allColors.Length)];
                }
                break;

            case ColorMode.Gradient:
                colors = GenerateGradientColors(dialog.Length, baseColor, ConsoleColor.Blue);
                break;

            case ColorMode.Blinking:
                for (int i = 0; i < dialog.Length; i++)
                {
                    colors[i] = i % 2 == 0 ? baseColor : ConsoleColor.White;
                }
                break;
        }

        return colors;
    }

    // Helper method to generate gradient colors
    private static ConsoleColor[] GenerateGradientColors(int length, ConsoleColor start, ConsoleColor end)
    {
        ConsoleColor[] allColors = Enum.GetValues(typeof(ConsoleColor))
            .Cast<ConsoleColor>()
            .ToArray();

        int startIndex = Array.IndexOf(allColors, start);
        int endIndex = Array.IndexOf(allColors, end);

        ConsoleColor[] colors = new ConsoleColor[length];
        for (int i = 0; i < length; i++)
        {
            double ratio = (double)i / (length - 1);
            int colorIndex = (int)(startIndex + ratio * (endIndex - startIndex));
            colors[i] = allColors[colorIndex];
        }

        return colors;
    }
}