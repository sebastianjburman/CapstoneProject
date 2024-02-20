namespace MessageForwarderSystem.Services.DataServices.Interfaces;

public interface IAppointmentDataService : IDataServiceBase<Appointment>
{
    Task<Appointment> CheckInToAppointmentAsync(string phoneNumber, DateTime appointmentDate);
}