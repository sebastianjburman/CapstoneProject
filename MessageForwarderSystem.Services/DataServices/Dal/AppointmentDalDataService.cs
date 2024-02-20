namespace MessageForwarderSystem.Services.DataServices.Dal;

public class AppointmentDalDataService : DalDataServiceBase<Appointment>, IAppointmentDataService
{

    public AppointmentDalDataService(IAppointmentDalServiceWrapper serviceWrapper) : base(serviceWrapper)
    {
    }

    public async Task<Appointment> CheckInToAppointmentAsync(string phoneNumber, DateTime appointmentDate)
    {
        return await((IAppointmentDalServiceWrapper)ServiceWrapper).CheckInToAppointmentAsync(phoneNumber, appointmentDate);
    }
}