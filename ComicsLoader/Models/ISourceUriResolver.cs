namespace ComicsLoader.Models;

internal interface ISourceUriResolver
{
    Uri? Resolve(Uri root, string relativeSource);
}
