using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Tiposutilizador
    {
        public Tiposutilizador()
        {
            Utilizadores = new HashSet<Utilizadore>();
        }

        public int IdTipoUtilizador { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Utilizadore> Utilizadores { get; set; }
    }
}
