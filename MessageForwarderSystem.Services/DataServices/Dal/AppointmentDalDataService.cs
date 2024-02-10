namespace MessageForwarderSystem.Services.DataServices.Dal;

public class AppointmentDalDataService : DalDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentDalDataService(IAppointmentDalServiceWrapper serviceWrapper) : base(serviceWrapper)
    {
    }

    public async Task CheckInToAppointment(string phoneNumber, DateTime appointmentDate) => 
        await ((IAppointmentDalServiceWrapper)ServiceWrapper).CheckInToAppointment(phoneNumber, appointmentDate);
}