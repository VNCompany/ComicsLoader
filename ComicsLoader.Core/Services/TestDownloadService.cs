
namespace ComicsLoader.Core.Services;

public class TestDownloadService : IDownloadService
{
    public async Task<string> GetHtml(Uri uri)
    {
        return await File.ReadAllTextAsync("./test.html");
    }

    public void Dispose() { }
}
