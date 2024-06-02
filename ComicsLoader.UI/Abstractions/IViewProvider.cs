namespace ComicsLoader.UI.Abstractions;

public interface IViewProvider : IDisposable
{
    void Show();
    bool? ShowDialog();
    void Hide();
    void Close();
}
