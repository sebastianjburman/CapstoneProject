
namespace MessageForwarderSystem.Controllers;

/// <summary>
/// Class <c>TwilioController</c> Controller class responsible for handling incoming SMS messages from Twilio.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TwilioController : BaseCrudController<Appointment, TwilioController>
{
    private readonly IAppointmentDataService _appointmentDataService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TwilioController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance for logging.</param>
    public TwilioController(ILogger<TwilioController> logger, IAppointmentDataService appointment) : base (logger, appointment)
    {
        this._appointmentDataService = appointment;
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

    /// <summary>
    /// Method <c>TwilioCheckIntoAppointment</c>: Twilio SMS webhook check in endpoint
    /// This method is called by Twilio when a someone checks in through phone number. 
    /// </summary>
    /// <param name="twilioMessage">An instance of the TwilioMessage class containing message data.</param>
    /// <returns>An HTTP action result indicating the status of the operation.</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [HttpPost("checkIn")]
    [ApiVersion("2.0")]
    public async Task<ActionResult> TwilioCheckIntoAppointment([FromBody]TwilioMessage twilioMessage)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await _appointmentDataService.CheckInToAppointment(twilioMessage.From, DateTime.Today);
        }
        catch (Exception ex)
        {
            Logger.LogError($"There was an error checking in to appointment. {ex}");
            return BadRequest(ex.Message);
        }
        return Ok();
    }

}
