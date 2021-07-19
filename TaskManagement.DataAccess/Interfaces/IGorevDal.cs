using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Interfaces
{
    public interface IGorevDal : IGenericDal<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev,bool>>filter);
        List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa);
        Gorev GetirAciliyetileId(int id);
        List<Gorev> GetirileAppUserId(int appUserId);//almış olduğum id ile userın görevlerini getiricem
        Gorev GetirRaporlarileId(int id);

        int GetirGorevSayisiTamamlananileAppUserId(int id);
        int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id);
        int GetirGorevSayisiAtanmayiBekleyen();
        int GetirGorevTamamlanmis();
    }
}
