namespace ColorLoggerLibrary;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

public class ColorLogger
{
    /// <summary>
    /// Prints to console with color. Like Console.WriteLine() with colored foreground.
    ///Note that coloring only available on external OS terminals and Visual Studio and Visual Studio Code integrated terminal . Visual Studio and Visual Studio Code internalConsoke does not support coloring.
    /// </summary>
    /// <param name="msg">Message.</param>
    /// <param name="lvl">Log level.</param>
    public void Print(string msg, LogLevel lvl)
    {
        var consoleNotTerminal = Convert.ToDouble(Console.WindowWidth) == 0 ? true : false; // Console or terminal.
        Console.WriteLine(); //Empty space.

        if (consoleNotTerminal) // Console
        {

            Console.WriteLine($"{DateTime.Now} --> {lvl}\n---------------\n{msg}\n---------------");

        }

        else // Ternminal
        {
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
            StringBuilder header = new StringBuilder(); // String builder for title.
            var msgTitle = $"⎧{DateTime.Now} --> {lvl}⎫"; // Title
            var msgOut = $" → {msg}"; // Message

            // Append to title
            header.Append(msgTitle);
            for (int i = 0; i < Console.WindowWidth - msgTitle.Length - 1; i++)
            {
                header.Append("⎯");

            }


            // Calculating the lines.

            double divide = Convert.ToDouble(msgOut.Length) / Convert.ToDouble(Console.WindowWidth);
            divide = Math.Ceiling(divide);
            var chunk = msgOut.Length / Convert.ToInt32(divide) - 1;

            var title = header.ToString(); // Title
            header.Clear();
            //Print upper title.
            Console.WriteLine(title);

            StringBuilder body = new StringBuilder(); // String builder for body.
            if (divide <= 1) // If 0 (empty) or 1 line.
            {

                var printCount = Console.WindowWidth - msgOut.Length;


                for (int i = 0; i < printCount - 1; i++)
                {
                    if (i == 0)
                    {
                        body.Append($"⎮ {msgOut}");
                    }
                    else if (i != printCount - 2)
                    {
                        body.Append(" ");
                    }

                    else
                    {
                        body.Append("⎮");

                    }

                }
                Console.WriteLine(body.ToString()); // Print body.
                body.Clear();
            }

            else // 2 or more line.
            {
                var groups = msgOut.SplitwithCount(chunk).ToList();

                for (int i = 0; i < groups.Count(); i++)
                {

                    var printCount = Console.WindowWidth;
                    var startPrint = $"⎮ {groups[i]}";
                    body.Append(startPrint);
                    var spaceCount = printCount - startPrint.Length - 2;
                    if (spaceCount != 0) // If will filled space available.
                    {
                        for (int z = 0; z < spaceCount; z++)
                        {
                            body.Append(" ");
                        }
                    }

                    body.Append(" ⎮");





                    Console.WriteLine(body.ToString()); // Print body.
                    body.Clear();


                }
            }

            StringBuilder footer = new StringBuilder(); // String builder for footer.
            // Print footer.
            for (int i = 0; i < title.Length; i++)
            {
                footer.Append("⎯");
            }
            Console.WriteLine(footer.ToString()); // Print footer.
            footer.Clear();

            // Reset foreground.
            Console.ForegroundColor = ConsoleColor.White;

        }


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