namespace ComicsLoader.Core;

public class SaveItem
{
    public string RelativePart { get; set; } = string.Empty;
    public Uri? Url { get; set; }
    public bool IsCorrect => Url != null;

    public override string ToString() => IsCorrect ? Url!.ToString() : RelativePart;
}
