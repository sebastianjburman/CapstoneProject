namespace MessageForwarderSystem.Services.DataServices.Interfaces;

public interface IAppointmentDataService : IDataServiceBase<Appointment>
{
    Task<Appointment> CheckInToAppointment(string phoneNumber, DateTime appointmentDate);
}