using System;
using System.Collections.Generic;

namespace OF_Project.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? Gender { get; set; }

    public DateTime? Dob { get; set; }
}
