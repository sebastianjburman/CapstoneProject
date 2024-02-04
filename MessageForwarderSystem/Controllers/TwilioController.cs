
namespace MessageForwarderSystem.Controllers;

/// <summary>
/// Class <c>TwilioController</c> Controller class responsible for handling incoming SMS messages from Twilio.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TwilioController : BaseCrudController<Appointment, TwilioController>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="TwilioController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance for logging.</param>
    public TwilioController(ILogger<TwilioController> logger, IAppointmentDataService appointment) : base (logger, appointment)
    {
    }
    /// <summary>
    /// Method <c>PostTwilioMessage</c>: Twilio SMS webhook endpoint.
    /// This method is called by Twilio when a message is sent to the Twilio number.
    /// </summary>
    /// <param name="twilioMessage">An instance of the TwilioMessage class containing message data.</param>
    /// <returns>An HTTP action result indicating the status of the operation.</returns>
    [HttpPost("incomeMessage")]
    [ApiVersion("2.0")]
    public ActionResult PostTwilioMessage([FromBody]TwilioMessage twilioMessage)
    {
        Logger.LogInformation(twilioMessage.ToString());
        return Ok();
    }

}
