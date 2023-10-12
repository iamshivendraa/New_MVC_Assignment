using System;
using System.Collections.Generic;

namespace NewProject.Models;

public partial class Account
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Age { get; set; }

    public double Salary { get; set; }

    public string Department { get; set; } = null!;
}
