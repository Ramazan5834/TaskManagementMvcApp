using System.Collections.Generic;
using TaskManagement.Entities.Interfaces;

namespace TaskManagement.DataAccess.Interfaces
{
    public interface IGenericDal<Tablo> where Tablo : ITablo, new()
    {
        void Kaydet(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);

        Tablo GetirIdile(int id);
        List<Tablo> GetirHepsi();
    }
}
