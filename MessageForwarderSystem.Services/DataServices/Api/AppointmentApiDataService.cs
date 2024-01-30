namespace MessageForwarderSystem.Services.DataServices.Api;

public class AppointmentApiDataService : ApiDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentApiDataService(IAppointmentApiServiceWrapper serviceWrapper) : base (serviceWrapper){}
}