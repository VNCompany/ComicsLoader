using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.Services;
using ComicsLoader.UI.Abstractions;
using ComicsLoader.UI.Services.ViewsDispatcherComponents;

namespace ComicsLoader.UI
{
    static class ViewsDispatcherServiceExtension
    {
        public static void AddViewsDispatcher(this IServiceCollection services
            , Action<ViewsDispatcherConfiguration> configure)
        {
            var cfg = new ViewsDispatcherConfiguration();
            configure.Invoke(cfg);

            var bindings = cfg.ToDictionary();
            foreach (var binding in bindings.Keys)
                services.AddTransient(binding);

            services.AddSingleton<IViewsDispatcher, ViewsDispatcher>(sp => new ViewsDispatcher(sp, bindings));
        }
    }
}
