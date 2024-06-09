using System.Text;

namespace ComicsLoader.Core;

public static class StringExtensions
{
    public static string DeleteDangerousSymbols(this string input)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();
        var sb = new StringBuilder(input);
        foreach (var ch in invalidChars)
            sb.Replace(ch, '_');
        return sb.ToString();
    }
}
