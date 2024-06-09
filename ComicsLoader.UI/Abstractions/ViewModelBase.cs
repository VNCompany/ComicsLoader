using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComicsLoader.UI.Abstractions;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void Dispose() { }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void SetProperty<T>(ref T field, T newValue, bool callPropertyChanged = true, [CallerMemberName] string? propertyName = null)
    {
        field = newValue;
        if (callPropertyChanged)
            OnPropertyChanged(propertyName);
    }

    protected void Queue(Action action)
    {
        action.Invoke();
    }

    protected void ShowMessage(string message, string caption = "Notify") 
        => System.Windows.MessageBox.Show(message, caption);
}
