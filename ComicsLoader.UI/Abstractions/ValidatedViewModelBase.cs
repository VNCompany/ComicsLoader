using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComicsLoader.UI.Abstractions;

public class ValidatedViewModelBase : ViewModelBase, INotifyDataErrorInfo
{
    private readonly Dictionary<string, string?> _errors = [];

    public bool HasErrors => _errors.Count != 0;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName == null 
            || !_errors.TryGetValue(propertyName, out var propertyError)
            || propertyError == null
            )
            yield break;

        yield return propertyError;
    }

    protected void SetProperty<T>(ref T field, T newValue, string? error = null, bool callPropertyChanged = true, [CallerMemberName] string? propertyName = null)
    {
        SetProperty(ref field, newValue, callPropertyChanged, propertyName);

        if (propertyName == null)
            return;

        if (_errors.TryGetValue(propertyName, out var propertyError))
        {
            if (error != propertyError)
            {
                if (error == null)
                    _errors.Remove(propertyName);
                else
                    _errors[propertyName] = error;

                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
        else if (error != null)
        {
            _errors.Add(propertyName, error);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
