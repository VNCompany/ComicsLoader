using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.Services.ViewsDispatcherComponents;

namespace ComicsLoader.UI.Services;

internal class ViewsDispatcher : IViewsDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IImmutableDictionary<Type, Type> _bindings;

    public ViewsDispatcher(IServiceProvider serviceProvider, IImmutableDictionary<Type, Type> bindings)
    {
        _serviceProvider = serviceProvider;
        _bindings = bindings;
    }

    public IViewModelContext GetViewModelContext(ViewModelBase viewModel)
        => new ViewModelContext(_bindings[viewModel.GetType()], viewModel);
}
