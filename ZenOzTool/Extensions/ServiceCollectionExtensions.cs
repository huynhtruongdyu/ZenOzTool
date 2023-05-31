using ZenOzTool.Applications.Services;
using ZenOzTool.Infrastructure.Services;
using ZenOzTool.Models.Constants;

namespace ZenOzTool.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient(HttpClientConstants.SJC.Name, config =>
        {
            config.BaseAddress = new Uri(HttpClientConstants.SJC.Host);
        });
    }

    public static void AddDI(this IServiceCollection services)
    {
        services.AddScoped<IGoldRateService, GoldRateService>();
    }
}