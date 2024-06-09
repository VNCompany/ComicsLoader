using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;

namespace ComicsLoader.Core.Services;

public class HtmlService
{
    private static readonly Regex __htmlAttrRegex = new Regex(@"^(.+)/@([^/]+)$");

    public IEnumerable<string> LoadLinks(string content, string xPath)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(content);

        Match match = __htmlAttrRegex.Match(xPath);
        return !match.Success
            ? htmlDoc.DocumentNode.SelectNodes(xPath)
                                  .Select(n => n.InnerHtml)
            : htmlDoc.DocumentNode.SelectNodes(match.Groups[1].Value)
                                  .Select(n => n.GetAttributeValue(match.Groups[2].Value, string.Empty));
    }
}
