namespace MessageForwarderSystem.Services.ApiWrapper;

public class AppointmentApiServiceWrapper : ApiServiceWrapperBase<Appointment>, IAppointmentApiServiceWrapper
{
    public AppointmentApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings>
        apiSettingsMonitor) : base(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.AppointmentBaseUri)
    {
    }
}