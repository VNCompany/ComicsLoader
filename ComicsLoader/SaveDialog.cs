using ComicsLoader.Models;

namespace ComicsLoader;

public enum SaveDialogResult
{
    Save, AddToQueue, Cancel
}

public partial class SaveDialog : Form
{
    private readonly ComicsItem _comicsItem;

    private SaveDialogResult _dialogResult = SaveDialogResult.Cancel;

    public SaveDialog(ComicsItem item, int queueCount)
    {
        InitializeComponent();

        Dictionary<HrefType, RadioButton> _radioTypes = new()
        {
            [HrefType.Absolute] = rbAbsolute,
            [HrefType.Append] = rbAppend,
            [HrefType.Inject] = rbInject,
            [HrefType.InjectRoot] = rbInjectRoot,
        };

        _comicsItem = item;

        // Setup queue counter on buttons
        if (queueCount > 0)
            btnQueue.Text = $"Queue ({queueCount})";

        // Check current radio button by HrefType of ComicsItem
        _radioTypes[_comicsItem.Type].Checked = true;
    }

    private void rb_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.Checked)
        {
            try
            {
                _comicsItem.Type = Enum.Parse<HrefType>(rb.Text);
                SetCollectionOfElements();
            }
            catch (Exception ex)
            {
                Program.PrintError(ex, "Loading elements error");
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {

    }

    private void btnQueue_Click(object sender, EventArgs e)
    {

    }

    private void SetCollectionOfElements()
    {
        try
        {
            lbElements.Items.Clear();
            lbElements.Items.AddRange(_comicsItem.GetUrlsPreview().ToArray());
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            btnSave.Enabled = btnQueue.Enabled = lbElements.Items.Count > 0;
        }
    }
}
