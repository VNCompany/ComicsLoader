using System.Windows;
using System.Reflection;

using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Services;

internal class ViewsProviderService
{
    private readonly Dictionary<string, Type> _windowTypes;

    public ViewsProviderService()
    {
        _windowTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.BaseType?.Equals(typeof(Window)) ?? false)
            .ToDictionary(t => t.Name, t => t);
    }

    public ViewContext Get(string viewName)
    {
        var window = (Window)Activator.CreateInstance(_windowTypes[viewName])!;
        return new ViewContext(window);
    }

    public ViewContext<T> Get<T>(string viewName) where T : ViewModelBase
    {
        var window = (Window)Activator.CreateInstance(_windowTypes[viewName])!;
        return new ViewContext<T>(window);
    }
}
