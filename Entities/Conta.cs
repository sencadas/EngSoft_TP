using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Conta
    {
        public Conta()
        {
            Depositosaprasos = new HashSet<Depositosapraso>();
            Titulares = new HashSet<Titulare>();
        }

        public int IdConta { get; set; }
        public string Banco { get; set; }
        public string Nome { get; set; }
        public string Numconta { get; set; }

        public virtual ICollection<Depositosapraso> Depositosaprasos { get; set; }
        public virtual ICollection<Titulare> Titulares { get; set; }
    }
}
