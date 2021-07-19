using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGorevRepository : EfGenericRepository<Gorev>, IGorevDal
    {
        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.Aciliyet).Where(I => !I.Durum)
                .OrderByDescending(I => I.OlusturulmaTarih).ToList();
        }

        public List<Gorev> GetirTumTablolarla()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser).Where(I => !I.Durum)
                .OrderByDescending(I => I.OlusturulmaTarih).ToList();
        }

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser).Where(filter)
                .OrderByDescending(I => I.OlusturulmaTarih).ToList();

        }

        public List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa = 1)
        {
            using var context = new TaskManagementContext();
            var returnValue = context.Gorevler.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser)
                .Where(I => I.AppUserId == userId && I.Durum)
                .OrderByDescending(I => I.OlusturulmaTarih);
            toplamSayfa = (int)Math.Ceiling((double)returnValue.Count() / 3);
            return returnValue.Skip((aktifSayfa - 1) * 3).Take(3).ToList().ToList();
        }

        public Gorev GetirAciliyetileId(int id)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.Aciliyet).FirstOrDefault(I => !I.Durum && I.Id == id);
        }

        public List<Gorev> GetirileAppUserId(int appUserId)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Where(I => I.AppUserId == appUserId).ToList();
        }

        public Gorev GetirRaporlarileId(int id)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.Raporlar).Include(I => I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetirGorevSayisiTamamlananileAppUserId(int id)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Count(I => I.AppUserId == id && I.Durum);
        }

        public int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id)
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Count(I => I.AppUserId == id && !I.Durum);
        }

        public int GetirGorevSayisiAtanmayiBekleyen()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Count(I => I.AppUserId == null && !I.Durum);

        }
        
        public int GetirGorevTamamlanmis()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Count(I => I.Durum);


        }
    }
}
