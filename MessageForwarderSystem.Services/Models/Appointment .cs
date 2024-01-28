
using System.Reflection.Emit;

namespace MessageForwarderSystem.Services.Models;

public class Appointment : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; } // Consider using TimeSpan for better time handling
    public string EndTime { get; set; } // Consider using TimeSpan for better time handling
    public DateTime DateCreated { get; set; }
    public bool CanClientCancel { get; set; }
    public bool CanClientReschedule { get; set; }
    public List<Label> Labels { get; set; }
}