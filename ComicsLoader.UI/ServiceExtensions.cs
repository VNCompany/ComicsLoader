using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Services;
using ComicsLoader.UI.Services.ViewsDispatcherComponents;

namespace ComicsLoader.UI
{
    static class ServiceExtensions
    {
        public static void AddViewsDispatcher(this IServiceCollection services
            , Action<ViewsDispatcherConfiguration> configure)
        {
            var cfg = new ViewsDispatcherConfiguration();
            configure.Invoke(cfg);

            services.AddSingleton(sp => new ViewsDispatcher(sp, cfg.ToDictionary()));
        }
    }
}
