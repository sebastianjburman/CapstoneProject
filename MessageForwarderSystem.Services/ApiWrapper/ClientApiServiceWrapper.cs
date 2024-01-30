namespace MessageForwarderSystem.Services.ApiWrapper;

public class ClientApiServiceWrapper : ApiServiceWrapperBase<Client>, IClientApiServiceWrapper
{
    public ClientApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingMonitor) : base (client, apiSettingMonitor, apiSettingMonitor.CurrentValue.ClientBaseUri) {}
    
}