using System.Collections.Generic;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Interfaces
{
   public interface IBildirimDal:IGenericDal<Bildirim>
   {
       List<Bildirim> GetirOkunmayanlar(int AppUserId);
       int GetirOkunmayanSayisiileAppUserId(int AppUserId);
   }
}
