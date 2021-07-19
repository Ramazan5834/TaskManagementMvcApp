using System.Collections.Generic;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Interfaces
{
 public   interface IAppUserService
 {
     List<AppUser> GetirAdminOlmayanlar(); 
     List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa,string aranacakKelime, int aktifSayfa = 1);
     List<DualHelper> GetirEnCokGorevTamamlamisPersoneller();
     List<DualHelper> GetirEnCokGorevdeCalisanPersoneller();
    }
}
