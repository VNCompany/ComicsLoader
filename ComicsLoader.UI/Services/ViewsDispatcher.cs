using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.Services.ViewsDispatcherComponents;

namespace ComicsLoader.UI.Services;

class ViewsDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IImmutableDictionary<Type, Type> _bindings;

    public ViewsDispatcher(IServiceProvider serviceProvider, IImmutableDictionary<Type, Type> bindings)
    {
        _serviceProvider = serviceProvider;
        _bindings = bindings;
    }

    public TViewModel GetViewModel<TViewModel>() where TViewModel : IViewModel
    {
        var vm = _serviceProvider.GetRequiredService<TViewModel>();
        vm.ViewModelContext = new ViewModelContext(_bindings[typeof(TViewModel)]);
        return vm;
    }
}
