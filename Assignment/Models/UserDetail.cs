using System;
using System.Collections.Generic;

namespace NewProject.Models;

public partial class UserDetail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
