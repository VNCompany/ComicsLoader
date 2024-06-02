using System.Windows;

using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Services.ViewsDispatcherComponents;

class ViewModelContext : IViewModelContext
{
    private readonly Window _window;
    
    public ViewModelContext(Type windowType, IViewModel viewModel)
    {
        _window = (Window)Activator.CreateInstance(windowType)!;
        _window.DataContext = viewModel;
    }

    public bool? ShowDialog() => _window.ShowDialog();

    public void Show() => _window.Show();

    public void Close() => _window.Close();

    public void Hide() => _window.Hide();

    public void Dispose() => Close();
}
