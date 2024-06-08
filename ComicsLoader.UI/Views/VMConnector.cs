using System.Windows.Markup;
using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Views;

internal class VMConnector : MarkupExtension
{
    public static Func<Type, ViewModelBase?>? Resolver { private get; set; }

    public Type? Type { get; set; }

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        if (Type == null)
            throw new ArgumentNullException(nameof(Type));

        return Resolver?.Invoke(Type);
    }
}
