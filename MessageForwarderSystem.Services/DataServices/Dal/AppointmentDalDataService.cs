namespace MessageForwarderSystem.Services.DataServices.Dal;

public class AppointmentDalDataService : DalDataServiceBase<Appointment>, IAppointmentDataService
{
    private IAppointmentDalServiceWrapper _appointmentDalServiceWrapper;

    public AppointmentDalDataService(IAppointmentDalServiceWrapper serviceWrapper) : base(serviceWrapper)
    {
        _appointmentDalServiceWrapper = serviceWrapper;
    }

    public async Task CheckInToAppointment(string phoneNumber, DateTime appointmentDate) => 
        await _appointmentDalServiceWrapper.CheckInToAppointment(phoneNumber, appointmentDate);
}