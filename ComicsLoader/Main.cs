using System.Text.RegularExpressions;

using ComicsLoader.Models;

namespace ComicsLoader;

public partial class Main : Form
{
    private readonly Regex _rex = new Regex("^(.+)/@(.+)$");
    private readonly Uri _defaultUrl = new Uri("http://localhost");

    private Uri? _url;
    private bool _canClose = true;

    public Main()
    {
        InitializeComponent();

        new SaveDialog(new ComicsItem(_defaultUrl, ["/a.jpg"]), 0).ShowDialog();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_canClose)
            e.Cancel = true;
    }

    private async void tbUrl_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (Uri.TryCreate(tbUrl.Text, UriKind.Absolute, out _url))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _canClose = false;
                    rtbHtml.Enabled = false;

                    rtbHtml.Text = await LoadHtml(_url);
                }
                catch (AggregateException aggEx)
                {
                    foreach (var ex in aggEx.InnerExceptions)
                        Program.PrintError(ex, "Loading html error");
                }
                catch (Exception ex)
                {
                    Program.PrintError(ex, "Loading html error");
                }
                finally
                {
                    _canClose = true;
                    rtbHtml.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }
    }

    private void HtmlOrXPath_TextChanged(object sender, EventArgs e)
    {
        btnSearch.Enabled = !string.IsNullOrWhiteSpace(rtbHtml.Text)
                 && !string.IsNullOrWhiteSpace(cbXPath.Text);
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var item = new ComicsItem(_url ?? _defaultUrl, ParseElements(rtbHtml.Text, cbXPath.Text).ToList());
        }
        catch (Exception ex)
        {
            Program.PrintError(ex, "Parsing html error");
        }
    }

    private async Task<string> LoadHtml(Uri url)
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);

        return await response.Content.ReadAsStringAsync();
    }

    private IEnumerable<string> ParseElements(string html, string xPath)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);

        Match match = _rex.Match(xPath);
        return match.Success
            ? doc.DocumentNode.SelectNodes(match.Groups[1].Value)
                              .Select(n => n.Attributes[match.Groups[2].Value].Value)
            : doc.DocumentNode.SelectNodes(xPath)
                              .Select(t => t.InnerHtml);
    }
}
