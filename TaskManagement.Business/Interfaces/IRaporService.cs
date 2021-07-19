using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Interfaces
{
  public  interface IRaporService:IGenericService<Rapor>
    {
        Rapor GetirGorevileId(int id);
        int GetirRaporSayisiileAppUserId(int id);
        int GetirRaporSayisi();
    }
}
