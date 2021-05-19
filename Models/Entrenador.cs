using System.Collections.Generic;

namespace entrenadores.Models
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Pueblo Pueblo { get; set; }
        public string Foto{ get; set; }

         // EF Shadow property
        public int PuebloId { get; set; }
        public ICollection<Entrenador> Entrenadores { get; set; }
       
    }
}