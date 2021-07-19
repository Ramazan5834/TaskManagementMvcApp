using System.Collections.Generic;
using TaskManagement.Entities.Interfaces;

namespace TaskManagement.Entities.Concrete
{
   public class Aciliyet:ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Gorev> Gorevler { get; set; }

    }
}
