using System.IO;

using ComicsLoader.UI.Common;
using ComicsLoader.UI.Abstractions;

using ComicsLoader.Core;

namespace ComicsLoader.UI.ViewModels;

internal class AddToQueueViewModel : ViewModelBase
{
    public SaveCollection SaveCollection { get; set; } = null!;

    #region PROPERTIES

    public IEnumerable<SaveItem> Items => SaveCollection.Items;

    private string _output = string.Empty;
    public string Output
    {
        get => _output;
        set => SetProperty(ref _output, value);
    }

    #endregion

    #region COMMANDS

    private RelayCommand? _openSaveDialog;
    public RelayCommand OpenSaveDialog
        => _openSaveDialog ??= new RelayCommand(OpenSaveDialog_Execute);

    #endregion

    public AddToQueueViewModel()
    {
        SaveCollection = new SaveCollection(new Uri("https://domain.com/"), "/test/", ["a.jpg", "b.jpg"]);
        SaveCollection.ResolveUrls(Constants.DefaultUrlResolver);
    }

    private void OpenSaveDialog_Execute(object? _)
    {
        var saveDialog = new Microsoft.Win32.OpenFolderDialog() { Multiselect = false };
        if (saveDialog.ShowDialog() == true)
            Output = Path.Combine(saveDialog.FolderName, SaveCollection.SuggestedDirectoryName ?? string.Empty);
    }
}
