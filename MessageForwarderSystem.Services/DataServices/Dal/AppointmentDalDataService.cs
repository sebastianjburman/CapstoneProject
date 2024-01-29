namespace MessageForwarderSystem.Services.DataServices.Dal;

public class AppointmentDalDataService : DalDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentDalDataService(IAppointmentDalServiceWrapper serviceWrapper) : base(serviceWrapper) { }
}