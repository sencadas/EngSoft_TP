using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Ativo
    {
        public Ativo()
        {
            Movimentos = new HashSet<Movimento>();
        }

        public int IdAtivo { get; set; }
        public int Duracaomeses { get; set; }
        public int Impost { get; set; }
        public string Nome { get; set; }
        public DateTime Datainicio { get; set; }
        public int? IdUtilizador { get; set; }

        public virtual Utilizadore IdUtilizadorNavigation { get; set; }
        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
