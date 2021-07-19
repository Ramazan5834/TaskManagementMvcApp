using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Concrete
{
    public class GorevManager : IGorevService
    {
        private readonly IGorevDal _gorevDal;

        public GorevManager(IGorevDal gorevDal)
        {
            _gorevDal = gorevDal;
            //_gorevDal=new EfGorevRepository();
        }

        public void Kaydet(Gorev tablo)
        {
            _gorevDal.Kaydet(tablo);
        }

        public void Sil(Gorev tablo)
        {
            _gorevDal.Sil(tablo);
        }

        public void Guncelle(Gorev tablo)
        {
            _gorevDal.Guncelle(tablo);
        }

        public Gorev GetirIdile(int id)
        {
            return _gorevDal.GetirIdile(id);
        }

        public List<Gorev> GetirHepsi()
        {
            return _gorevDal.GetirHepsi();
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            return _gorevDal.GetirAciliyetIleTamamlanmayan();
        }

        public List<Gorev> GetirTumTablolarla()
        {
            return _gorevDal.GetirTumTablolarla();
        }

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            return _gorevDal.GetirTumTablolarla(filter);
        }

        public List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa)
        {
            return _gorevDal.GetirTumTablolarlaTamamlanmayan(out toplamSayfa, userId, aktifSayfa);
        }

        public Gorev GetirAciliyetileId(int id)
        {
            return _gorevDal.GetirAciliyetileId(id);
        }

        public List<Gorev> GetirileAppUserId(int appUserId)
        {
            return _gorevDal.GetirileAppUserId(appUserId);
        }

        public Gorev GetirRaporlarileId(int id)
        {
            return _gorevDal.GetirRaporlarileId(id);
        }

        public int GetirGorevSayisiTamamlananileAppUserId(int id)
        {
            return _gorevDal.GetirGorevSayisiTamamlananileAppUserId(id);
        }

        public int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id)
        {
            return _gorevDal.GetirGorevSayisiTamamlanmasiGerekenileAppUserId(id);
        }

        public int GetirGorevSayisiAtanmayiBekleyen()
        {
            return _gorevDal.GetirGorevSayisiAtanmayiBekleyen();
        }

        public int GetirGorevTamamlanmis()
        {
            return _gorevDal.GetirGorevTamamlanmis();
        }
    }
}
