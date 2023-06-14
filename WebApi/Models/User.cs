using Microsoft.AspNetCore.Identity;

namespace WebApi.Models;

public class User : IdentityUser
{

    public User()
    {
        
    }
    public User(string fullName, DateTimeOffset dateOfBirth)
    {
        if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException(nameof(fullName));
        
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public string FullName { get; private set; } = string.Empty;
    public DateTimeOffset DateOfBirth { get; private set; }

}
