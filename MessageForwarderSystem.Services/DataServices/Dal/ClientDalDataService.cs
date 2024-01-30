using MessageForwarderSystem.Services.DataServices.Dal.Base;

namespace MessageForwarderSystem.Services.DataServices.Dal;

public class ClientDalDataService : DalDataServiceBase<Client>, IClientDataService
{
    public ClientDalDataService(IClientDalServiceWrapper serviceWrapper) : base (serviceWrapper){}
}