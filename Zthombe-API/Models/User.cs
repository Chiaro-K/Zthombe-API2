using System;
using System.Collections.Generic;

namespace Zthombe_API.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string? Username { get; set; }
}
