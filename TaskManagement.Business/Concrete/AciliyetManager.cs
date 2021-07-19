using System.Collections.Generic;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Concrete
{
 public   class AciliyetManager:IAciliyetService
 {
     private readonly IAciliyetDal _aciliyetDal;

     public AciliyetManager(IAciliyetDal aciliyetDal)
     {
         _aciliyetDal = aciliyetDal;
         //_aciliyetDal = new EfAciliyetRepository();
     }

        public void Kaydet(Aciliyet tablo)
        {
            _aciliyetDal.Kaydet(tablo);
        }

        public void Sil(Aciliyet tablo)
        {
            _aciliyetDal.Sil(tablo);
        }

        public void Guncelle(Aciliyet tablo)
        {
            _aciliyetDal.Guncelle(tablo);
        }

        public Aciliyet GetirIdile(int id)
        {
          return _aciliyetDal.GetirIdile(id);
        }

        public List<Aciliyet> GetirHepsi()
        {
           return _aciliyetDal.GetirHepsi();
        }
    }
}
