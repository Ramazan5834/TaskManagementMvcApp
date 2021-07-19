using TaskManagement.Entities.Interfaces;

namespace TaskManagement.Entities.Concrete
{
  public  class Bildirim:ITablo
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
