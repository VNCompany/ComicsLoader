using System.Windows;
using System.Collections.Immutable;

using ComicsLoader.UI.Abstractions;

namespace ComicsLoader.UI.Services.ViewsDispatcherComponents;

class ViewsDispatcherConfiguration
{
    private readonly HashSet<(Type, Type)> _bindings = [];

    public void AddBinding<TViewModel, TWindow>() where TViewModel : IViewModel
                                                  where TWindow : Window
    {
        _bindings.Add((typeof(TViewModel), typeof(TViewModel)));
    }

    public ImmutableDictionary<Type, Type> ToDictionary()
        => _bindings.ToImmutableDictionary(k => k.Item1, v => v.Item2);
}
