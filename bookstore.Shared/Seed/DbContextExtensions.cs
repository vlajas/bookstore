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

            if (!context.Book.Any())
            {
                context.Book.Add(new Book { Title = "It", Author = "Stephen King", Category = "Horror", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51XZmlCYjaL._SX342_.jpg", Isbn = "1501182099", Language = "English", NumberOfPages = 1168, Price = 2199.99m, Publisher = "Scribner", PublicationDate = new DateTime(2017, 7, 11)});
                context.Book.Add(new Book { Title = "The Stand", Author = "Stephen King", Category = "Horror, Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41DmhS44V-L._SX320_BO1,204,203,200_.jpg", Isbn = "0307947300", Language = "English", NumberOfPages = 1200, Price = 1199.99m, Publisher = "Anchor", PublicationDate = new DateTime(2012, 8, 7) });
                context.Book.Add(new Book { Title = "The Green Mile", Author = "Stephen King", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61Ds826BlCL.jpg", Isbn = "1501192264", Language = "English", NumberOfPages = 432, Price = 986.78m, Publisher = "Gallery Books", PublicationDate = new DateTime(2018, 4, 17) });
                context.Book.Add(new Book { Title = "Carrie", Author = "Stephen King", Category = "Horror", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51eYJY7IRFL._SX322_BO1,204,203,200_.jpg", Isbn = "1984898108", Language = "English", NumberOfPages = 320, Price = 689.79m, Publisher = "Anchor", PublicationDate = new DateTime(2018, 12, 31) });
                context.Book.Add(new Book { Title = "Nigh Shift", Author = "Stephen King", Category = "Horror", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51U85n7%2BsjL.jpg", Isbn = "0307947297", Language = "English", NumberOfPages = 384, Price = 520.21m, Publisher = "Anchor", PublicationDate = new DateTime(2012, 8, 7) });
                context.Book.Add(new Book { Title = "A Game of Thrones: A Song of Ice and Fire, Book 1", Author = "George R. R. Martin", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61lu4iDmAEL._SX342_.jpg", Isbn = "0345535413", Language = "English", NumberOfPages = 704, Price = 1700m, Publisher = "Bantam", PublicationDate = new DateTime(2002, 5, 28) });
                context.Book.Add(new Book { Title = "A Clash of Kings: A Song of Ice and Fire, Book 2", Author = "George R. R. Martin", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/511%2BDbzTZ%2BL._SX342_.jpg", Isbn = "9780553381689", Language = "English", NumberOfPages = 784, Price = 1750m, Publisher = "Bantam", PublicationDate = new DateTime(2012, 3, 6) });
                context.Book.Add(new Book { Title = "A Storm of Swords: A Song of Ice and Fire, Book 3", Author = "George R. R. Martin", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51buL9HEMjL._SX342_.jpg", Isbn = "0345543971", Language = "English", NumberOfPages = 1008, Price = 1800m, Publisher = "Bantam", PublicationDate = new DateTime(2013,3,26) });
                context.Book.Add(new Book { Title = "A Feast for Crows: A Song of Ice and Fire, Book 4", Author = "George R. R. Martin", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51d%2B0wrDwbL._SX342_.jpg", Isbn = "0553582038", Language = "English", NumberOfPages = 784, Price = 1850m, Publisher = "Bantam", PublicationDate = new DateTime(2007, 10, 30) });
                context.Book.Add(new Book { Title = "A Dance with Dragons: A Song of Ice and Fire, Book 5", Author = "George R. R. Martin", Category = "Fiction", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51DGe0uFHCL._SX330_BO1,204,203,200_.jpg", Isbn = "1101886048", Language = "English", NumberOfPages = 1056 , Price = 1900, Publisher = "Bantam", PublicationDate = new DateTime(2015, 3, 31) });
                context.Book.Add(new Book { Title = "Beogradski Trio", Author = "Goran Markovic", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/4146/beogradski_trio-goran_markovic_v.jpg", Isbn = "978-86-521-3141-9", Language = "Serbian", NumberOfPages = 200, Price = 699m, Publisher = "Laguna", PublicationDate = new DateTime(2018,12,12) });
                context.Book.Add(new Book { Title = "Covek po imenu Uve", Author = "Fredrik Bakman", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/3366/covek_po_imenu_uve_v.jpg", Isbn = "978-86-521-2465-7", Language = "Serbian", NumberOfPages = 360, Price = 899m, Publisher = "Laguna", PublicationDate = new DateTime(2017,2,20) });
                context.Book.Add(new Book { Title = "Meseceva sestra", Author = "Lusina Rajli", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/4104/meseceva_sestra-lusinda_rajli_v.jpg", Isbn = "978-86-521-3176-1", Language = "Serbian", NumberOfPages = 680, Price = 1299m, Publisher = "Laguna", PublicationDate = new DateTime(2018,12,14) });
                context.Book.Add(new Book { Title = "Beleske jedne Ane", Author = "Momo Kapor", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/4077/beleske_jedne_ane-momo_kapor_v.jpg", Isbn = "978-86-521-2884-6", Language = "Serbian", NumberOfPages = 344, Price = 799m, Publisher = "Laguna", PublicationDate = new DateTime(2018,10,23) });
                context.Book.Add(new Book { Title = "Moja baka vam se izvinjava", Author = "Fredrik Bakman", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/3745/moja_baka_vam_se_izvinjava-fredrik_bakman_v.jpg", Isbn = "978-86-521-2896-9", Language = "Serbian", NumberOfPages = 456, Price = 999m, Publisher = "Laguna", PublicationDate = new DateTime(2018,3,1) });
                context.Book.Add(new Book { Title = "Kuca na jezeru", Author = "Kejt Morton", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/4047/kuca_na_jezeru-kejt_morton_v.jpg", Isbn = "978-86-521-3119-8", Language = "Serbian", NumberOfPages = 544, Price = 1399m, Publisher = "Laguna", PublicationDate = new DateTime(2018,12,6) });
                context.Book.Add(new Book { Title = "Hipi", Author = "Paulo Koeljo", Category = "Drama", ImageUrl = "https://www.laguna.rs/_img/korice/3914/hipi-paulo_koeljo_v.jpg", Isbn = "978-86-521-3092-4", Language = "Serbian", NumberOfPages = 253, Price = 699m, Publisher = "Laguna", PublicationDate = new DateTime(2018, 9, 17) });

                context.SaveChanges();
            }
        }
    }
}
