using System.Collections.Generic;

namespace entrenadores.Models
{
    public class Pueblo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Entrenador> Entrenadores { get; set; }

    }
}