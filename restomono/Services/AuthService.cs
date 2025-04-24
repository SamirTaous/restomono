using Microsoft.EntityFrameworkCore;
using restomono.Models;

namespace restomono.Services;

public static class AuthService
{
    // ✅ Allow setting CurrentUser from outside (e.g., PaymentPage)
    public static User CurrentUser { get; set; }

    public static async Task<bool> LoginAsync(string username)
    {
        using var context = new PlatDbContext();
        var user = await context.Users.FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
        if (user != null)
        {
            CurrentUser = user;
            return true;
        }
        return false;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }
}
