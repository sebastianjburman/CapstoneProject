

namespace MessageForwarderSystem.Services.DataServices;

public static class DataServiceConfiguration
{
    public static IServiceCollection AddDataServices(
        this IServiceCollection services, IConfiguration config)
    {
        bool.TryParse(config["UseApi"], out bool api);
        api = api || false;         
        if (api)
        {
            services.AddScoped<IAppointmentDataService, AppointmentApiDataService>();
            services.AddScoped<IClientDataService, ClientApiDataService>();
        }
        else
        {
            services.AddScoped<IAppointmentDataService, AppointmentDalDataService>();
            services.AddScoped<IAppointmentDalServiceWrapper, AppointmentDalServiceWrapper>();
            // we are not using client for data.json
            //services.AddScoped<IClientDataService, ClientDalDataService>();
            services.AddScoped<IClientDalServiceWrapper, ClientDalServiceWrapper>();
        }
        return services;
    }
}