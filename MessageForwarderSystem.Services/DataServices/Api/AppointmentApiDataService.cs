namespace MessageForwarderSystem.Services.DataServices.Api;

public class AppointmentApiDataService : ApiDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentApiDataService(IApiServiceWrapperBase<Appointment> serviceWrapperBase) : base(serviceWrapperBase)
    {
    }
    public Task<Appointment> CheckInToAppointmentAsync(string phoneNumber, DateTime appointmentDate)
    {
        throw new NotImplementedException();
    }
}