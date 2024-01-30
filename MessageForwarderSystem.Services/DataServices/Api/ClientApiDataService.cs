namespace MessageForwarderSystem.Services.DataServices.Api;

public class ClientApiDataService : ApiDataServiceBase<Client>, IClientDataService
{
    public ClientApiDataService(IClientApiServiceWrapper serviceWrapper) : base (serviceWrapper) {}
}