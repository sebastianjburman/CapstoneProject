﻿namespace MessageForwarderSystem.Services.Models;

public class Client : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }
}