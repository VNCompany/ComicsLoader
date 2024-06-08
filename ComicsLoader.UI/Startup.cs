using System.Windows;
using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Services;
using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.ServiceExtensions;

namespace ComicsLoader.UI;

class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ViewsProviderService>();
        services.AddViewModels();
    }

    public void Run(IServiceProvider serviceProvider, StartupEventArgs e)
    {
        Views.VMConnector.Resolver = type => serviceProvider.GetService(type) as ViewModelBase;

        var viewsProvider = serviceProvider.GetRequiredService<ViewsProviderService>();
        viewsProvider.Get("MainWindow").Show();
    }
}
