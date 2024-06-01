using Microsoft.Extensions.DependencyInjection;
using System.Windows;

using ComicsLoader.UI.Services;

namespace ComicsLoader.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewsDispatcher = _serviceProvider.GetRequiredService<ViewsDispatcher>();
        }
    }
}
