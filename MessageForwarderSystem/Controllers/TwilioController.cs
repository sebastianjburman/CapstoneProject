using Microsoft.AspNetCore.Mvc;
using MessageForwarderSystem.Models;
using MessageForwarderSystem.Services.DataServices.Interfaces;

namespace MessageForwarderSystem.Controllers;

/// <summary>
/// Class <c>TwilioController</c> Controller class responsible for handling incoming SMS messages from Twilio.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TwilioController : ControllerBase
{
    private readonly ILogger<TwilioController> _logger;
    private readonly IDataServiceBase<Appointment> _appointment;

    /// <summary>
    /// Initializes a new instance of the <see cref="TwilioController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance for logging.</param>
    public TwilioController(ILogger<TwilioController> logger, IDataServiceBase<Appointment> _appointment)
    {
        _logger = logger;
        _appointment = _appointment;
    }
    /// <summary>
    /// Method <c>PostTwilioMessage</c>: Twilio SMS webhook endpoint.
    /// This method is called by Twilio when a message is sent to the Twilio number.
    /// </summary>
    /// <param name="twilioMessage">An instance of the TwilioMessage class containing message data.</param>
    /// <returns>An HTTP action result indicating the status of the operation.</returns>
    [HttpPost]
    public ActionResult PostTwilioMessage([FromForm]TwilioMessage twilioMessage)
    {
        _logger.LogInformation(twilioMessage.ToString());
        _appointment.GetAllAsync();
        return Ok();
    }
}
