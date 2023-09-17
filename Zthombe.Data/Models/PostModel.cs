using System;
namespace Zthombe.Data.Models
{
  public class PostModel
  {
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Tags { get; set; }
  }
    public class CreatePostModel
  {
    public Guid UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
  }
}

