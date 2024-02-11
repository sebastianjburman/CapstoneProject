namespace MessageForwarderSystem.Services.DataServices.Api;

public class AppointmentApiDataService : ApiDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentApiDataService(IAppointmentApiServiceWrapper serviceWrapper) : base (serviceWrapper){}
    public async Task<Appointment> CheckInToAppointment(string phoneNumber, DateTime appointmentDate)
    {
        throw new NotImplementedException();
    }
}