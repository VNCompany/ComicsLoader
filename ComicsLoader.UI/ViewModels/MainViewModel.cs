using ComicsLoader.UI.Abstractions;
using System.ComponentModel;

namespace ComicsLoader.UI.ViewModels;

internal class MainViewModel : ViewModelBase
{
    private Uri? _rootUrl;
    public Uri? RootUrl
    {
        get => _rootUrl;
        set => _rootUrl = value;
    }

    private string? _content;
    public string? Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();
        }
    }
}
