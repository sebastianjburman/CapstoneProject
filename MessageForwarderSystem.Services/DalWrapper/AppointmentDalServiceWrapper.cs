using MessageForwarderSystem.Services.DalWrapper.Base;

namespace MessageForwarderSystem.Services.DalWrapper;

public class AppointmentDalServiceWrapper : DalServiceWrapperBase<Appointment>, IAppointmentDalServiceWrapper
{
    public AppointmentDalServiceWrapper(IConfiguration config) : base (config) {}

    private async Task<Appointment> GetAppointmentTodayByPhoneNumberAsync(string phoneNumber, DateTime appointmentDate)
    {
        IList<Appointment> appointments = await ReadFromFileAsync();
        return appointments.FirstOrDefault(a => a.Date.Date == appointmentDate.Date.Date && a.Phone.Equals(phoneNumber));
    }

    public async Task<Appointment> CheckInToAppointmentAsync(string phoneNumber, DateTime appointmentDate)
    {
        try
        {
            Appointment? appointment = await GetAppointmentTodayByPhoneNumberAsync(phoneNumber, appointmentDate);
            if (appointment is null)
            {
                throw new Exception($"Could not find appointment on date {appointmentDate.Date.Date.ToShortDateString()} for phone number {phoneNumber}");
            }
            //Api only accepts one label
            appointment.Labels.Clear();
            appointment.Labels.Add(new Label() { Id = 3, Color = "Yellow", Name = "Checked In" });
            return await UpdateEntityAsync(appointment);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}