using System.Windows;

using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Services.ViewsDispatcherComponents.ViewProviders;

internal class WindowProvider<T> : IViewProvider where T : Window, new()
{
    private readonly Window _window;

    public WindowProvider()
    {
        _window = new T();
    }

    public void Show()
    {
        _window.Show();
    }

    public bool? ShowDialog()
    {
        return _window.ShowDialog();
    }

    public void Hide()
    {
        _window.Hide();
    }

    public void Close()
    {
        _window.Close();
    }

    public void Dispose()
    {
        Close();
    }
}
