namespace ComicsLoader.UI;

internal static class Constants
{
    public static readonly Uri DefaultUri = new Uri("http://localhost");

    public static readonly Func<Uri, string, Uri?> DefaultUrlResolver = (root, relative) =>
    {
        if ((relative.StartsWith("http://") || relative.StartsWith("https://")) 
            && Uri.TryCreate(relative, UriKind.Absolute, out var result)
            || Uri.TryCreate(root, relative, out result))
            return result;

        return null;
    };
}
