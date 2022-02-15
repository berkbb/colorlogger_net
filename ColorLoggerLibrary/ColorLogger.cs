namespace ColorLoggerLibrary;
using System.Diagnostics;
using System.Text;

public class ColorLogger
{
    /// <summary>
    /// Prints to console with color. Like Console.WriteLine() with colored foreground.
    ///Note that coloring only available on external OS terminals. Visual Studio and Visual Studio Code does not support coloring.
    /// </summary>
    /// <param name="msg">Message.</param>
    /// <param name="lvl">Log level.</param>
    public void Print(string msg, LogLevel lvl)
    {
        Console.WriteLine(); //Empty space.

        //Foreground selector.
        switch (lvl)
        {
            case LogLevel.verbose:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case LogLevel.debug:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case LogLevel.info:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case LogLevel.warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogLevel.error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }
        StringBuilder title = new StringBuilder(); // String builder for title.
        var msgTitle = $"[{lvl}]"; // Title
        var msgOut = $"> {msg}"; // Message

        // Append to title
        title.Append(msgTitle);
        for (int i = 0; i < Console.WindowWidth - msgTitle.Length - 1; i++)
        {
            title.Append("-");

        }
        var upper = title.ToString(); // Upper

        // Calculating the lines.
        double divide = Convert.ToDouble(msgOut.Length) / Convert.ToDouble(Console.WindowWidth);
        divide = Math.Ceiling(divide);

        //Print upper title.
        Console.WriteLine(upper);

        if (divide <= 1) // If 0 (empty) or 1 line.
        {
            var newOut = $"| {msgOut}";
            var printCount = Console.WindowWidth - newOut.Length;

            for (int i = 0; i < printCount; i++)
            {
                if (i == 0)
                {
                    Console.Write($"| {msgOut}");
                }
                else if (i != printCount - 1)
                {
                    Console.Write(" ");
                }

                else
                {
                    Console.Write("|");

                }

            }
            Console.WriteLine();
        }

        else // 2 or more line.
        {
            int stringStartIndex = 0;

            for (int i = 0; i < divide; i++)
            {

                if (i == 0)
                {
                    var firstSub = msgOut.Substring(0, Console.WindowWidth - 4);
                    stringStartIndex = firstSub.Length - 2;
                    var newOut = $"| {firstSub} |";


                    Console.WriteLine(newOut);

                }
                else
                {

                    var printCount = Console.WindowWidth;
                    for (int j = 0; j < printCount; j++)
                    {
                        if (j == 0)
                        {
                            Console.Write($"|");
                        }
                        else if (j != printCount - 1)
                        {
                            Console.Write(" ");
                        }

                        else
                        {
                            Console.Write("|");

                        }

                    }
                    Console.WriteLine();
                }


            }
        }


        // Print footer.
        for (int i = 0; i < upper.Length; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine(); //Empty space.

        // Reset foreground.
        Console.ForegroundColor = ConsoleColor.White;
    }



}
/// <summary>
/// Log level enum.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Verbose - yellow
    /// </summary>
    verbose,
    /// <summary>
    /// Debug - cyan.
    /// </summary>
    debug,
    /// <summary>
    /// İnfo - green.
    /// </summary>
    info,
    /// <summary>
    /// Warning -- yellow.
    /// </summary>
    warning,
    /// <summary>
    /// Error - red.
    /// </summary>
    error,
    /// <summary>
    /// Standart text print - white.
    /// </summary>
    unknown

}