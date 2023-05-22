using System;
using System.Collections.Generic;

namespace Zthombe_API.Models;

public partial class Post
{
    public Guid PostId { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Tags { get; set; }

    public int PostType { get; set; }

    public DateTime DateCreated { get; set; }

    public int ViewCount { get; set; }
}
