using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
   public class EfRaporRepository:EfGenericRepository<Rapor>,IRaporDal
    {
        public Rapor GetirGorevileId(int id)
        {
            using var context = new TaskManagementContext();
            return context.Raporlar.Include(I => I.Gorev).ThenInclude(I=>I.Aciliyet).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            using var context = new TaskManagementContext();
            var result = context.Gorevler.Include(I => I.Raporlar).Where(I => I.AppUserId == id);
            return result.SelectMany(I => I.Raporlar).Count();
        }

        public int GetirRaporSayisi()
        {
            using var context = new TaskManagementContext();
            return context.Raporlar.Count();

        }
    }
}
