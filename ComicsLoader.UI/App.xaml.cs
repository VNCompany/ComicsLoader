﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ComicsLoader.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Startup _startup = new();
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            _startup.ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _startup.Run(_serviceProvider, e);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _serviceProvider.Dispose();
        }
    }
}
