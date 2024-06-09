using System.Text.RegularExpressions;

namespace ComicsLoader.Core;

public class SaveCollection
{
    public Uri Root { get; }
    public string? XPath { get; set; }
    
    public List<SaveItem> Items { get; private set; }
    public string? SuggestedDirectoryName { get; set; }
    public string? OutputPath { get; set; }


    public SaveCollection(Uri root, string xPath, IEnumerable<string> links)
    {
        Root = root;
        XPath = xPath;
        Items = links.Select(link => new SaveItem { RelativePart = link }).ToList();

        SuggestDirectoryName();
    }

    public void ResolveUrls(Func<Uri, string, Uri?> resolver)
    {
        Items.ForEach(item => item.Url = resolver.Invoke(Root, item.RelativePart));
    }

    public void SuggestDirectoryName()
    {
        if (Root.Segments.Length > 0 && Root.Segments[^1] != "/")
            SuggestedDirectoryName = Root.Segments[^1];
        else if (Root.Segments.Length > 1 && Root.Segments[^2] != "/")
            SuggestedDirectoryName = Root.Segments[^2];
        else
            SuggestedDirectoryName = Root.Host;

        SuggestedDirectoryName = SuggestedDirectoryName.DeleteDangerousSymbols().TrimEnd('_');
    }
}
