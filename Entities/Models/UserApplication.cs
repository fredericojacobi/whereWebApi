using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class UserApplication : IdentityUser<Guid>
{
    public Guid Id { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}