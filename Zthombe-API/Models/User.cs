using System;
using System.Collections.Generic;

namespace Zthombe_API.Models;

public partial class User
{
    public Guid UserId { get; set; }
    public string FirebaseUserId { get; set; } = String.Empty;
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Post> Posts { get; set; }
}
