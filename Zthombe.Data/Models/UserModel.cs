using System;
namespace Zthombe.Data.Models
{
  public class UserModel
  {
    public Guid UserId { get; set; }
    public string? Username { get; set; }
  }


}
public class CreateUserModel
{
    public string Username { get; set; }
    public string FirebaseUserId { get; set; }

}
