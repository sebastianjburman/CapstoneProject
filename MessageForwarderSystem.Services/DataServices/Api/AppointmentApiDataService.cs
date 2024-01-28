using MessageForwarderSystem.Services.ApiWrapper.Interfaces;
using MessageForwarderSystem.Services.DataServices.Api.Base;
using MessageForwarderSystem.Services.DataServices.Interfaces;

namespace MessageForwarderSystem.Services.DataServices.Api;

public class AppointmentApiDataService : ApiDataServiceBase<Appointment>, IAppointmentDataService
{
    public AppointmentApiDataService(IAppointmentApiServiceWrapper serviceWrapper) : base (serviceWrapper){}
}