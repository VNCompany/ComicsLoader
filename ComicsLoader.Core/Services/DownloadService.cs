namespace ComicsLoader.Core.Services
{
    internal class DownloadService : IDownloadService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetHtml(Uri uri)
        {
            var response = await _httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
