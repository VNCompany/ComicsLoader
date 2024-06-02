using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Services.ViewsDispatcherComponents.ViewProviders;
using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.ViewModels;

namespace ComicsLoader.UI;

class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddViewsDispatcher(cfg =>
        {
            cfg.AddBinding<MainViewModel, WindowProvider<Views.MainWindow>>();
        });
    }

    public void Run(IServiceProvider serviceProvider)
    {
        var dispatcher = serviceProvider.GetRequiredService<IViewsDispatcher>();
        var vm = serviceProvider.GetRequiredService<MainViewModel>();

        dispatcher.GetViewModelContext(vm).Show();
    }
}
