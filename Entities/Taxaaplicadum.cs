using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Taxaaplicadum
    {
        public int IdTaxa { get; set; }
        public int Mes { get; set; }
        public int Taxa { get; set; }
        public int? IdFundo { get; set; }

        public virtual Fundoinvestimento IdFundoNavigation { get; set; }
    }
}
