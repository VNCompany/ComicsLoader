using ComicsLoader.Models;
using ComicsLoader.Models.SourceUriResolvers;
using ComicsLoader.Services;

namespace ComicsLoader;

public partial class Main : Form
{
    private readonly IDownloadService _downloadService = new DownloadService();

    public Main()
    {
        InitializeComponent();
        _ = Some();
    }

    private async Task Some()
    {
        var sc = new SaveCollection(_downloadService);
        await sc.LoadRoot("https://telegra.ph/Loliplex-3--Istoriya-o-borbe-s-gryazyu-05-21");
        rtbHtml.Text = sc.Content;

        try
        {
            sc.LoadItems("//article//img/@src", new DefaultUriResolver(disableErrors: true));
            MessageBox.Show(string.Join("\n", sc.Items?.Select(it => it.Value?.ToString() ?? "NULL") ?? []));
        }
        catch (Exception ex)
        {
            Program.PrintError(ex);
        }
    }
}
