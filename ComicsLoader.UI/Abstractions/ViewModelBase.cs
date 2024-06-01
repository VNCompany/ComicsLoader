using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComicsLoader.UI.Abstractions;

abstract class ViewModelBase : IViewModel
{
    public IViewModelContext? ViewModelContext { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dispose()
    {
        ViewModelContext?.Dispose();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
