namespace ComicsLoader.Models;

public enum HrefType
{
    Absolute, Inject, InjectRoot, Append
}

public class ComicsItem
{

    private readonly Uri _rootUrl;

    public List<string> SourceElements { get; set; }

    public HrefType Type { get; set; }

    public string? OutputDir { get; set; }

    public List<Uri>? Elements { get; set; }

    public ComicsItem(Uri rootUrl, List<string> sourceElements)
    {
        _rootUrl = rootUrl;
        SourceElements = sourceElements;
        
        if (sourceElements.Count == 0)
            throw new ArgumentException("Collection is empty", nameof(sourceElements));

        DetermineType();
    }

    public IEnumerable<Uri> GetUrlsPreview()
    {
        Uri _preparedRoot = Type switch
        {
            HrefType.InjectRoot => new UriBuilder(_rootUrl.Scheme, _rootUrl.Host).Uri,
            HrefType.Inject => new UriBuilder
            {
                Scheme = _rootUrl.Scheme,
                Host = _rootUrl.Host,
                Path = _rootUrl.Segments.Length == 0
                    ? string.Empty
                    : string.Join("/", _rootUrl.Segments[..^1])
            }.Uri,
            _ => _rootUrl
        };

        foreach (string sourceElement in SourceElements)
        {
            bool isSuccess = Type == HrefType.Absolute
                ? Uri.TryCreate(sourceElement, UriKind.Absolute, out Uri? uri)
                : Uri.TryCreate(_preparedRoot, sourceElement, out uri);

            if (!isSuccess)
                throw new InvalidOperationException($"Invalid part: {sourceElement}");

            yield return uri!;
        }
    }

    private void DetermineType()
    {
        string firstElement = SourceElements[0];

        if (firstElement.StartsWith('/'))
            Type = HrefType.InjectRoot;
        else if (firstElement.StartsWith("http://")
                 || firstElement.StartsWith("https://"))
            Type = HrefType.Absolute;
        else if (_rootUrl.PathAndQuery.EndsWith('/'))
            Type = HrefType.Append;
        else
            Type = HrefType.Inject;
    }
}
