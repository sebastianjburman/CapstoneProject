
using MessageForwarderSystem.Services.ApiWrapper;
using MessageForwarderSystem.Services.DataServices.Interfaces;

namespace MessageForwarderSystem.Services.DataServices;

public static class DataServiceConfiguration
{
    public static IServiceCollection AddDataServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAppointmentDataService, AppointmentApiDataService>();
        services.AddScoped<IAppointmentApiServiceWrapper, AppointmentApiServiceWrapper>();

        return services;
    }
}