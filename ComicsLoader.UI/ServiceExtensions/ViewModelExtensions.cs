using Microsoft.Extensions.DependencyInjection;

using ComicsLoader.UI.ViewModels;

namespace ComicsLoader.UI.ServiceExtensions;

internal static class ViewModelExtensions
{
    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        services.AddTransient<AddToQueueViewModel>();
    }
}
