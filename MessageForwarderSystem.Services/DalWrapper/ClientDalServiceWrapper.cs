using MessageForwarderSystem.Services.DalWrapper.Base;
using MessageForwarderSystem.Services.DalWrapper.Interfaces;

namespace MessageForwarderSystem.Services.DalWrapper;

public class ClientDalServiceWrapper : DalServiceWrapperBase<Client>, IClientDalServiceWrapper
{
     public ClientDalServiceWrapper (IConfiguration config) : base (config) {}
}