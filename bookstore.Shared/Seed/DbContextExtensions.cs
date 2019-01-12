using System;
using System.Linq;
using bookstore.Shared.Entities;

namespace bookstore.Shared.Seed
{
    public static class DbContextExtensions
    {
        public static void Seed(this BookstoreDbContext context)
        {
            if (!context.Role.Any())
            {
                context.Add(new Role { Name = "Admin" });
                context.Add(new Role { Name = "User" });
                context.SaveChanges();
            }

            if (!context.User.Any())
            {
                var adminUser = new User
                {
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "admin",
                    Password = "12345"
                };

                context.Add(adminUser);

                context.SaveChanges();
                
                if (!context.UserRoleMapping.Any())
                {
                    context.UserRoleMapping.Add(new UserRoleMapping { UserId = adminUser.Id, RoleId =  context.Role.FirstOrDefault(x=> x.Name == "Admin")?.Id ?? throw new InvalidOperationException() });

                    context.SaveChanges();
                }
            }
        }
    }
}
