namespace MessageForwarderSystem.Models;

/// <summary>
/// Represents a model for handling incoming messages from Twilio.
/// </summary>
public class TwilioMessage
{
    /// <summary>
    /// Gets or sets the first name associated with the Twilio message.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name associated with the Twilio message.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the Twilio message.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the message content of the Twilio message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the country code of the recipient of the Twilio message.
    /// </summary>
    public string? ToCountry { get; set; }

    /// <summary>
    /// Gets or sets the submission status of the Twilio message.
    /// </summary>
    public string? Submit { get; set; }

    /// <summary>
    /// Gets or sets the state of the recipient of the Twilio message.
    /// </summary>
    public string? ToState { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the Twilio SMS message.
    /// </summary>
    public string? SmsMessageSid { get; set; }

    /// <summary>
    /// Gets or sets the number of media attachments in the Twilio message.
    /// </summary>
    public int NumMedia { get; set; }

    /// <summary>
    /// Gets or sets the city of the recipient of the Twilio message.
    /// </summary>
    public string? ToCity { get; set; }

    /// <summary>
    /// Gets or sets the ZIP code of the sender of the Twilio message.
    /// </summary>
    public string? FromZip { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the Twilio SMS.
    /// </summary>
    public string? SmsSid { get; set; }

    /// <summary>
    /// Gets or sets the state of the sender of the Twilio message.
    /// </summary>
    public string? FromState { get; set; }

    /// <summary>
    /// Gets or sets the status of the Twilio SMS.
    /// </summary>
    public string? SmsStatus { get; set; }

    /// <summary>
    /// Gets or sets the city of the sender of the Twilio message.
    /// </summary>
    public string? FromCity { get; set; }

    /// <summary>
    /// Gets or sets the body (content) of the Twilio message.
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// Gets or sets the country code of the sender of the Twilio message.
    /// </summary>
    public string? FromCountry { get; set; }

    /// <summary>
    /// Gets or sets the recipient phone number for the Twilio message.
    /// </summary>
    public string? To { get; set; }

    /// <summary>
    /// Gets or sets the ZIP code of the recipient of the Twilio message.
    /// </summary>
    public string? ToZip { get; set; }

    /// <summary>
    /// Gets or sets the number of segments in the Twilio message.
    /// </summary>
    public int NumSegments { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the Twilio message.
    /// </summary>
    public string? MessageSid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the Twilio account.
    /// </summary>
    public string? AccountSid { get; set; }

    /// <summary>
    /// Gets or sets the sender phone number for the Twilio message.
    /// </summary>
    public string? From { get; set; }

    /// <summary>
    /// Gets or sets the API version used by Twilio for sending the message.
    /// </summary>
    public string? ApiVersion { get; set; }

    /// <summary>
    /// Overrides the default ToString method to provide a formatted string representation of the TwilioMessage instance.
    /// </summary>
    /// <returns>A string containing all the properties and their values of the TwilioMessage instance.</returns>
    public override string ToString()
    {
        return $"FirstName: {FirstName}, " +
               $"LastName: {LastName}, " +
               $"Email: {Email}, " +
               $"Message: {Message}, " +
               $"ToCountry: {ToCountry}, " +
               $"Submit: {Submit}, " +
               $"ToState: {ToState}, " +
               $"SmsMessageSid: {SmsMessageSid}, " +
               $"NumMedia: {NumMedia}, " +
               $"ToCity: {ToCity}, " +
               $"FromZip: {FromZip}, " +
               $"SmsSid: {SmsSid}, " +
               $"FromState: {FromState}, " +
               $"SmsStatus: {SmsStatus}, " +
               $"FromCity: {FromCity}, " +
               $"Body: {Body}, " +
               $"FromCountry: {FromCountry}, " +
               $"To: {To}, " +
               $"ToZip: {ToZip}, " +
               $"NumSegments: {NumSegments}, " +
               $"MessageSid: {MessageSid}, " +
               $"AccountSid: {AccountSid}, " +
               $"From: {From}, " +
               $"ApiVersion: {ApiVersion}";
    }
}
