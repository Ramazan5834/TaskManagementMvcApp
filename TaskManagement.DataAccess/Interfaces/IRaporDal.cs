using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Interfaces
{
   public interface IRaporDal:IGenericDal<Rapor>
   {
       Rapor GetirGorevileId(int id);
       int GetirRaporSayisiileAppUserId(int id);
       int GetirRaporSayisi();
   }
}
