using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComicsLoader.UI.Abstractions;

internal abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void Dispose() { }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
