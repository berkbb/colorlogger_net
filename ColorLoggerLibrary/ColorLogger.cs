namespace ColorLoggerLibrary;

using System.Text;

public sealed class ColorLogger
{
    /// <summary>
    /// Prints a message using a colored layout when an interactive terminal is available.
    /// Falls back to plain output for redirected output or unsupported consoles.
    /// </summary>
    public void Print(string msg, LogLevel lvl)
    {
        msg ??= string.Empty;

        Console.WriteLine();

        if (!SupportsColorLayout())
        {
            Console.WriteLine($"{DateTime.Now:O} --> {lvl}\n---------------\n{msg}\n---------------");
            return;
        }

        var previousColor = Console.ForegroundColor;

        try
        {
            Console.ForegroundColor = GetColorForLevel(lvl);

            var width = Math.Max(GetConsoleWidth(), 24);
            var title = BuildTitle(lvl, width);
            var bodyWidth = Math.Max(1, width - 4); // "⎮ " + text + " ⎮"
            var message = $" → {msg}";

            Console.WriteLine(title);

            foreach (var line in message.SplitWithCount(bodyWidth))
            {
                Console.WriteLine($"⎮ {line.PadRight(bodyWidth)} ⎮");
            }

            Console.WriteLine(new string('⎯', title.Length));
        }
        finally
        {
            Console.ForegroundColor = previousColor;
        }
    }

    private static string BuildTitle(LogLevel level, int width)
    {
        var header = $"⎧{DateTime.Now:yyyy-MM-dd HH:mm:ss} --> {level}⎫";
        if (header.Length >= width)
        {
            return header;
        }

        var builder = new StringBuilder(width);
        builder.Append(header);
        builder.Append('⎯', width - header.Length);
        return builder.ToString();
    }

    private static int GetConsoleWidth()
    {
        try
        {
            return Console.WindowWidth;
        }
        catch
        {
            return 0;
        }
    }

    private static bool SupportsColorLayout() =>
        !Console.IsOutputRedirected &&
        !Console.IsErrorRedirected &&
        GetConsoleWidth() > 0;

    private static ConsoleColor GetColorForLevel(LogLevel level) =>
        level switch
        {
            LogLevel.verbose => ConsoleColor.Cyan,
            LogLevel.debug => ConsoleColor.Magenta,
            LogLevel.info => ConsoleColor.Green,
            LogLevel.warning => ConsoleColor.Yellow,
            LogLevel.error => ConsoleColor.Red,
            _ => ConsoleColor.White,
        };
}

/// <summary>
/// Log level enum.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Verbose - cyan.
    /// </summary>
    verbose,

    /// <summary>
    /// Debug - magenta.
    /// </summary>
    debug,

    /// <summary>
    /// Info - green.
    /// </summary>
    info,

    /// <summary>
    /// Warning - yellow.
    /// </summary>
    warning,

    /// <summary>
    /// Error - red.
    /// </summary>
    error,

    /// <summary>
    /// Standard text print - white.
    /// </summary>
    unknown,
}
