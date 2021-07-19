using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin"
                });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole()
                {
                    Name = "Member"
                });
            }

            var adminUser = await userManager.FindByNameAsync("yavuz");
            if (adminUser == null)
            {
                AppUser user = new AppUser()
                {
                    Name = "Ramazan",
                    Surname = "İşçanan",
                    UserName = "ramazan",
                    Email = "ramazan@gmail.com"
                };
                await userManager.CreateAsync(user, "1");//user'ı ekle parolasınıda 1 yap'
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
