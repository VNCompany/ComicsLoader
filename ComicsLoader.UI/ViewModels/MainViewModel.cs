using ComicsLoader.UI.Abstractions;
using System.ComponentModel;

namespace ComicsLoader.UI.ViewModels;

internal class MainViewModel : ValidatedViewModelBase
{
    private Uri _rootUrl = Constants.DefaultUri;

    private string _rootUrlString = string.Empty;
    public string RootUrlString
    {
        get => _rootUrlString;
        set
        {
            string? error = null;
            if (value != string.Empty && !Uri.TryCreate(value, UriKind.Absolute, out _))
                error = "Invalid uri";

            SetProperty(ref _rootUrlString, value, error, callPropertyChanged: false);
        }
    }
}
