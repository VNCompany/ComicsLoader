using Microsoft.Extensions.DependencyInjection;

namespace ComicsLoader.UI;

class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddViewsDispatcher(cfg =>
        {
            // Views and ViewModels bindings
        });
    }
}
