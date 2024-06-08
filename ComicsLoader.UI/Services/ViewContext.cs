using System.Windows;

using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Services;

public class ViewContext
{
    protected readonly Window _window;

    public object? ViewModel { get; }

    public ViewContext(Window window)
    {
        _window = window;
        ViewModel = _window.DataContext;
    }

    public void Show() => _window.Show();

    public void Hide() => _window.Hide();

    public void Close() => _window.Close();

    public bool? ShowDialog() => _window.ShowDialog();
}

public class ViewContext<T> : ViewContext where T : ViewModelBase
{
    public object Descriptor => _window;

    public new T? ViewModel { get; }

    public ViewContext(Window window) : base(window)
    {
        if (window.DataContext is T viewModel)
            ViewModel = viewModel;
    }
}
