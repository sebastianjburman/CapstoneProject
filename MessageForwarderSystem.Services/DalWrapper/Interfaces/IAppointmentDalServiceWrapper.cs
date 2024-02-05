namespace MessageForwarderSystem.Services.DalWrapper.Interfaces;

public interface IAppointmentDalServiceWrapper : IDalServiceWrapperBase<Appointment>
{
    Task CheckInToAppointment(string phoneNumber, DateTime appointmentDate);
}