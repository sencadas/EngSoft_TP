using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Depositosapraso
    {
        public int IdDeposito { get; set; }
        public double Valor { get; set; }
        public string Montanteaplicado { get; set; }
        public int Taxajuroanual { get; set; }
        public int? IdConta { get; set; }

        public virtual Conta IdContaNavigation { get; set; }
    }
}
