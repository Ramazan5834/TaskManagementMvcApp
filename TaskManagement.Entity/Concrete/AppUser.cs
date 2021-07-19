using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Entities.Interfaces;

namespace TaskManagement.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Bildirim> Bildirimler { get; set; }
        public List<Gorev> Gorevler { get; set; }
    }
}
