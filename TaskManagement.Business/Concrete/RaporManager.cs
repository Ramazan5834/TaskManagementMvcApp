using System.Collections.Generic;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Concrete
{
  public  class RaporManager:IRaporService
  {
      private readonly IRaporDal _raporDal;

      public RaporManager(IRaporDal raporDal)
      {
          _raporDal = raporDal;
          //raporRepository = new EfRaporRepository();
      }

        public void Kaydet(Rapor tablo)
        {
            _raporDal.Kaydet(tablo);
        }

        public void Sil(Rapor tablo)
        {
            _raporDal.Sil(tablo);
        }

        public void Guncelle(Rapor tablo)
        {
            _raporDal.Guncelle(tablo);
        }

        public Rapor GetirIdile(int id)
        {
            return _raporDal.GetirIdile(id);
        }

        public List<Rapor> GetirHepsi()
        {
            return _raporDal.GetirHepsi();
        }

        public Rapor GetirGorevileId(int id)
        {
            return _raporDal.GetirGorevileId(id);
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            return _raporDal.GetirRaporSayisiileAppUserId(id);
        }

        public int GetirRaporSayisi()
        {
            return _raporDal.GetirRaporSayisi();
        }
  }
}
