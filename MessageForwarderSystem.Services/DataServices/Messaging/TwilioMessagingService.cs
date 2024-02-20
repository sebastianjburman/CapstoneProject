using MessageForwarderSystem.Services.DataServices.Messaging.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageForwarderSystem.Services.DataServices.Messaging;

public class TwilioMessagingService : IMessagingService
{
    private readonly TwilioMessagingServiceSettings _twilioMessagingServiceSettings;
    public TwilioMessagingService(IOptionsMonitor<TwilioMessagingServiceSettings> optionsMonitor){
        _twilioMessagingServiceSettings = optionsMonitor.CurrentValue;
        if(_twilioMessagingServiceSettings.AccountSid!=null && _twilioMessagingServiceSettings.AuthToken!=null && _twilioMessagingServiceSettings.FromPhoneNumber!=null){
           TwilioClient.Init(_twilioMessagingServiceSettings.AccountSid, _twilioMessagingServiceSettings.AuthToken); 
        }
        else{
            throw new Exception("Twilio AccountSid, AuthToken or FromPhoneNumber is null in app settings");
        }
    }

    public bool SendMessage(string number, string message)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(number));
        messageOptions.From = new PhoneNumber(_twilioMessagingServiceSettings.FromPhoneNumber);
        messageOptions.Body = message;

        var messageSent = MessageResource.Create(messageOptions);
        Console.WriteLine(messageSent.Body);
        return true;
    }
}

