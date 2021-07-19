using System.Collections.Generic;
using System.Linq;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Interfaces;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {

        public void Kaydet(Tablo tablo)
        {
            using var context = new TaskManagementContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new TaskManagementContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new TaskManagementContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public Tablo GetirIdile(int id)
        {
            using var context = new TaskManagementContext();
            return context.Set<Tablo>().Find(id);
        }

        public List<Tablo> GetirHepsi()
        {
            using var context = new TaskManagementContext();
            return context.Set<Tablo>().ToList();
        }
    }
}
