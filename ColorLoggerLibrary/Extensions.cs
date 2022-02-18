public static class Extensions
{
    public static IEnumerable<string> SplitwithCount(this string str, int chunkLength)
    {
        if (String.IsNullOrEmpty(str)) throw new ArgumentException();
        if (chunkLength < 1) throw new ArgumentException();

        for (int i = 0; i < str.Length; i += chunkLength)
        {
            if (chunkLength + i > str.Length)
                chunkLength = str.Length - i;

            yield return str.Substring(i, chunkLength);
        }
    }
}