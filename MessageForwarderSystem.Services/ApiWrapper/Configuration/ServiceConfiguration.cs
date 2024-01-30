namespace MessageForwarderSystem.Services.ApiWrapper.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApiServiceWrapper(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ApiServiceSettings>(options => config.GetSection(nameof(ApiServiceSettings)));

        services.AddHttpClient<IAppointmentApiServiceWrapper, AppointmentApiServiceWrapper>();
        services.AddHttpClient<IClientApiServiceWrapper, ClientApiServiceWrapper>();

        return services;
    }
}