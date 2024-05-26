namespace ComicsLoader.Models;

internal record SaveItem
{
    public Uri Root { get; }
    public string RelativeSource { get; }
    public Uri? Value { get; }

    public SaveItem(Uri root, string relativeSource, ISourceUriResolver resolver)
    {
        Root = root;
        RelativeSource = relativeSource;
        Value = resolver.Resolve(root, relativeSource);
    }

    public SaveItem(Uri root, string relativeSource)
    {
        Root = root;
        RelativeSource = relativeSource;
    }
}
