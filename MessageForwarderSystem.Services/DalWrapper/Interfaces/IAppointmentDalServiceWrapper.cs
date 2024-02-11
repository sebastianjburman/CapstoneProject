namespace MessageForwarderSystem.Services.DalWrapper.Interfaces;

public interface IAppointmentDalServiceWrapper : IDalServiceWrapperBase<Appointment>
{
    Task<Appointment> CheckInToAppointmentAsync(string phoneNumber, DateTime appointmentDate);
}