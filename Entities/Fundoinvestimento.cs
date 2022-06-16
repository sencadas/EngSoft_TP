using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Fundoinvestimento
    {
        public Fundoinvestimento()
        {
            Taxaaplicada = new HashSet<Taxaaplicadum>();
        }

        public int IdFundo { get; set; }
        public string Nome { get; set; }
        public double Montanteinvestido { get; set; }
        public int Taxajuro { get; set; }

        public virtual ICollection<Taxaaplicadum> Taxaaplicada { get; set; }
    }
}
