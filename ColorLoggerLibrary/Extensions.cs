namespace ColorLoggerLibrary;

public static class Extensions
{
    public static IEnumerable<string> SplitWithCount(this string str, int chunkLength)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (chunkLength < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(chunkLength), chunkLength, "Chunk length must be greater than zero.");
        }

        if (str.Length == 0)
        {
            yield return string.Empty;
            yield break;
        }

        for (var i = 0; i < str.Length; i += chunkLength)
        {
            var currentLength = Math.Min(chunkLength, str.Length - i);
            yield return str.Substring(i, currentLength);
        }
    }

    // Backward compatible alias for older consumers.
    public static IEnumerable<string> SplitwithCount(this string str, int chunkLength) =>
        SplitWithCount(str, chunkLength);
}
