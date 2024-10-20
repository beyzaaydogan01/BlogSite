
namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record CreateUserRequest(
    string FirstName, 
    string LastName, 
    string Email, 
    string Username,
    string Password);