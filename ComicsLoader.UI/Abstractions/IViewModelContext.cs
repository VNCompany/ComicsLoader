namespace ComicsLoader.UI.Abstractions;

interface IViewModelContext : IDisposable
{
    bool? ShowDialog();
    void Show();
    void Hide();
    void Close();
}