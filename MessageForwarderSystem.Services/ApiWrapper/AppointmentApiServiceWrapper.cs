using MessageForwarderSystem.Services.ApiWrapper.Base;
using MessageForwarderSystem.Services.ApiWrapper.Interfaces;
using MessageForwarderSystem.Services.DataServices.Api.Base;

namespace MessageForwarderSystem.Services.ApiWrapper;

public class AppointmentApiServiceWrapper : ApiServiceWrapperBase<Appointment>, IAppointmentApiServiceWrapper
{
    public AppointmentApiServiceWrapper() : base()
    {
    }
}