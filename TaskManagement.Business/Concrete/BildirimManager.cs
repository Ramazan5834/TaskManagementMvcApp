using System.Collections.Generic;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Concrete
{
   public class BildirimManager:IBildirimService
   {
       private readonly IBildirimDal _bildirimDal;
        public BildirimManager(IBildirimDal bildirimDal)
        {
            _bildirimDal = bildirimDal;
        }

        public void Kaydet(Bildirim tablo)
        {
           _bildirimDal.Kaydet(tablo);
        }

        public void Sil(Bildirim tablo)
        {
          _bildirimDal.Sil(tablo);
        }

        public void Guncelle(Bildirim tablo)
        {
            _bildirimDal.Guncelle(tablo);
        }

        public Bildirim GetirIdile(int id)
        {
            return _bildirimDal.GetirIdile(id);
        }

        public List<Bildirim> GetirHepsi()
        {
            return _bildirimDal.GetirHepsi();
        }

        public List<Bildirim> GetirOkunmayanlar(int AppUserId)
        {
            return _bildirimDal.GetirOkunmayanlar(AppUserId);
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            return _bildirimDal.GetirOkunmayanSayisiileAppUserId(AppUserId);
        }
   }
}
