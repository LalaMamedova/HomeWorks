using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server_app.Context;

public class APIUserContext : IdentityDbContext<IdentityUser>
{
    public APIUserContext(DbContextOptions<APIUserContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
