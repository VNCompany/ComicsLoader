using System.Text.RegularExpressions;

using ComicsLoader.Core.Services;

namespace ComicsLoader.Core.Models;

internal class SaveCollection
{
    private static readonly Regex __htmlAttrRegex = new Regex(@"^(.+)/@([^/]+)$");

    public Uri Root { get; }
    public string? Content { get; set; }
    public string? XPath { get; set; }
    
    public List<SaveItem> Items { get; private set; }
    public string? OutputDir { get; set; }


    public SaveCollection(Uri root, string content, string xPath)
    {
        Root = root;
        Content = content;
        XPath = xPath;
        Items = LoadLinks(Content, xPath).Select(link => new SaveItem
        {
            RelativePart = link
        }).ToList();
    }

    public void ResolveUrls(Func<Uri, string, Uri?> resolver)
    {
        Items.ForEach(item => item.Url = resolver.Invoke(Root, item.RelativePart));
    }

    private static IEnumerable<string> LoadLinks(string content, string xPath)
    {
        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(content);

        Match match = __htmlAttrRegex.Match(xPath);
        return !match.Success
            ? htmlDoc.DocumentNode.SelectNodes(xPath)
                                  .Select(n => n.InnerHtml)
            : htmlDoc.DocumentNode.SelectNodes(match.Groups[1].Value)
                                  .Select(n => n.GetAttributeValue(match.Groups[2].Value, string.Empty));
    }
}
