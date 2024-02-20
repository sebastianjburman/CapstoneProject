namespace MessageForwarderSystem.Services.DataServices.Interfaces;

public interface IMessagingService{
    bool SendMessage(string number, string message);
}