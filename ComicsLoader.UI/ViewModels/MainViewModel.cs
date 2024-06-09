using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.Common;
using ComicsLoader.UI.Services;

using ComicsLoader.Core.Services;

namespace ComicsLoader.UI.ViewModels;

internal class MainViewModel : ValidatedViewModelBase
{
    private readonly IDownloadService _downloader;

    #region PROPERTIES

    private bool _isNotBusy = true;
    public bool IsNotBusy
    {
        get => _isNotBusy;
        set => SetProperty(ref _isNotBusy, value);
    }

    private Uri _rootUrl = Constants.DefaultUri;
    private string _rootUrlString = string.Empty;
    public string RootUrlString
    {
        get => _rootUrlString;
        set
        {
            string? error = null;
            if (value == string.Empty) { }
            else if (Uri.TryCreate(value, UriKind.Absolute, out var uriResult))
            {
                _rootUrl = uriResult;
                LoadHtml();
            }
            else
                error = "Invalid URL";

            SetProperty(ref _rootUrlString, value, error, callPropertyChanged: false);
        }
    }

    private string _html = string.Empty;
    public string Html
    {
        get => _html;
        set
        {
            SetProperty(ref _html, value);
            Parse.RaiseCanExecuteChanged();
        }
    }

    private string _xPath = string.Empty;
    public string XPath
    {
        get => _xPath;
        set
        {
            SetProperty(ref _xPath, value);
            Parse.RaiseCanExecuteChanged();
        }
    }

    #endregion

    #region COMMANDS

    private RelayCommand? _parse;
    public RelayCommand Parse
        => _parse ??= new RelayCommand(Parse_Execute, Parse_CanExecute);

    #endregion

    public MainViewModel(IDownloadService downloader)
    {
        _downloader = downloader;
    }

    private void LoadHtml()
    {
        Queue(async () =>
        {
            IsNotBusy = false;
            await Task.Delay(2000);
            try
            {
                Html = await _downloader.GetHtml(_rootUrl);
            }
            catch (Exception ex)
            {
                ShowMessage("HTML loading error", ex.Message);
            }
            IsNotBusy = true;
        });
    }

    private bool Parse_CanExecute(object? _)
    => !string.IsNullOrWhiteSpace(Html) && !string.IsNullOrWhiteSpace(XPath);

    private void Parse_Execute(object? _)
    {
        ShowMessage("Hello");
    }
}
