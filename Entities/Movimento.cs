using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Movimento
    {
        public int IdMovimento { get; set; }
        public double Valor { get; set; }
        public int Taxa { get; set; }
        public DateTime Data { get; set; }
        public int? IdAtivo { get; set; }

        public virtual Ativo IdAtivoNavigation { get; set; }
    }
}
