using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Utilizadore
    {
        public Utilizadore()
        {
            Ativos = new HashSet<Ativo>();
        }

        public int IdUtilizador { get; set; }
        public string Primeironome { get; set; }
        public string Ultimonome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public DateTime? Datanascimento { get; set; }
        public int? IdTipoUtilizador { get; set; }

        public virtual Tiposutilizador IdTipoUtilizadorNavigation { get; set; }
        public virtual ICollection<Ativo> Ativos { get; set; }
    }
}
