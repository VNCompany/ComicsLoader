namespace ComicsLoader.Models.SourceUriResolvers;

internal class DefaultUriResolver : ISourceUriResolver
{
    private readonly bool _disableErrors;

    public DefaultUriResolver(bool disableErrors = false)
    {
        _disableErrors = disableErrors;
    }

    public Uri? Resolve(Uri root, string relativeSource)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(relativeSource))
                throw new ArgumentNullException(nameof(relativeSource));

            relativeSource = relativeSource.Trim().ToLower();
            if (relativeSource.StartsWith("http://") || relativeSource.StartsWith("https://"))
                return new Uri(relativeSource, UriKind.Absolute);

            return new Uri(root, relativeSource);
        }
        catch (Exception)
        {
            if (!_disableErrors) throw;

            return null;
        }
    }
}
