using MessageForwarderSystem.Services.DalWrapper.Base;

namespace MessageForwarderSystem.Services.DalWrapper;

public class AppointmentDalServiceWrapper : DalServiceWrapperBase<Appointment>, IAppointmentDalServiceWrapper
{
    public AppointmentDalServiceWrapper(IConfiguration config) : base (config) {}
    
}