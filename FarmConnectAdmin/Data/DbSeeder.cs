using FarmConnectAdmin.Data;
using FarmConnectAdmin.Models;
using FarmConnectAdmin.Utilities;

namespace FarmConnectAdmin.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            var adminUser = context.Admins.FirstOrDefault(a => a.Username == "admin");
            var hashedPassword = PasswordHelper.HashPassword("admin123");

            if (adminUser == null)
            {
                adminUser = new Admin
                {
                    Username = "admin",
                    Password = hashedPassword
                };
                context.Admins.Add(adminUser);
            }
            else
            {
                // Force update password to ensure hashing is applied
                adminUser.Password = hashedPassword;
                context.Admins.Update(adminUser);
            }
            
            context.SaveChanges();
        }
    }
}
