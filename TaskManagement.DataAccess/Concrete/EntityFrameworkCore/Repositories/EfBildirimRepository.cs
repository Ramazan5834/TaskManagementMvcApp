using System.Collections.Generic;
using System.Linq;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
   public class EfBildirimRepository:EfGenericRepository<Bildirim>,IBildirimDal
    {
        public List<Bildirim> GetirOkunmayanlar(int AppUserId)
        {
            using var context = new ToDoContext();
            return context.Bildirimler.Where(I => I.AppUserId == AppUserId && !I.Durum).ToList();
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            using var context = new ToDoContext();
            return context.Bildirimler.Count(I => I.AppUserId == AppUserId && !I.Durum);

        }
    }
}
