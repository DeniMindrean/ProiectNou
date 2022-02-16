using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MindreanDenisaProject.Data;

namespace AdminConsoleApp
{
    class Program
    {
        private static string _connectionString = "Server=.;Database=ShelterV2;Trusted_Connection=True;";


        static async System.Threading.Tasks.Task Main(string[] args)
        {


            var options = new DbContextOptionsBuilder<ShelterContext>()
                .UseSqlServer(_connectionString)
                .Options;

            // With the options generated above, we can then just construct a new DbContext class
            using (var ctx = new ShelterContext(options))
            {

                string adminMail = "denisa.mindrean@yahoo.com";

                //var newUser = ctx.Users.Add(new IdentityUser
                //{
                //    UserName = adminMail,
                //    Email = adminMail,
                //    NormalizedEmail = adminMail.ToUpper(),
                //    Id = Guid.NewGuid().ToString(),
                //});


                //ctx.SaveChanges();


                var user = await ctx.Users.FirstOrDefaultAsync(acc => acc.Email == adminMail);
                if(user == null)
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
                user = await ctx.Users.FirstOrDefaultAsync(acc => acc.Email == adminMail);

                var role = await ctx.Roles.FirstOrDefaultAsync(role => role.Name == "Admin");

                if(role == null)
                {
                    ctx.Roles.Add(new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "Admin",

                    });
                    ctx.SaveChanges();
                }
                role = await ctx.Roles.FirstOrDefaultAsync(role => role.Name == "Admin");




                ctx.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });

                ctx.SaveChanges();

            }

        }
    }
}
