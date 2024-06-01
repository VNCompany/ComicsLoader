namespace ComicsLoader.Core.Services;

public interface IDownloadService : IDisposable
{
    Task<string> GetHtml(Uri uri);
}
