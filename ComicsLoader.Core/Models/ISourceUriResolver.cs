namespace ComicsLoader.Core.Models;

internal interface ISourceUriResolver
{
    Uri? Resolve(Uri root, string relativeSource);
}
