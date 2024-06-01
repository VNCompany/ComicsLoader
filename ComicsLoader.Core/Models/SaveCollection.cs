using System.Text.RegularExpressions;

using ComicsLoader.Core.Services;

namespace ComicsLoader.Core.Models;

internal class SaveCollection
{
    private static readonly Regex __htmlAttrRegex = new Regex(@"^(.+)/@([^/]+)$");

    private readonly IDownloadService _downloadService;

    public Uri Root { get; private set; } = new("http://localhost");
    public string? Content { get; set; }
    public string? XPath { get; set; }
    
    public List<SaveItem>? Items { get; private set; }
    public string? OutputDir { get; set; }


    public SaveCollection(IDownloadService downloadService)
    {
        _downloadService = downloadService;
    }

    public async Task LoadRoot(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? root))
            throw new InvalidOperationException($"Can't resolve URL `{url}`");

        Content = await _downloadService.GetHtml(root);

        Root = root;
    }

    public void LoadItems(string xPath, ISourceUriResolver resolver)
    {
        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(Content);

        Match match = __htmlAttrRegex.Match(xPath);
        IEnumerable<string> links = !match.Success
            ? htmlDoc.DocumentNode.SelectNodes(xPath)
                                  .Select(n => n.InnerHtml)
            : htmlDoc.DocumentNode.SelectNodes(match.Groups[1].Value)
                                  .Select(n => n.GetAttributeValue(match.Groups[2].Value, string.Empty));

        Items = links.Select(li => new SaveItem(Root, li, resolver)).ToList();
    }
}
