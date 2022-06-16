using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Titulare
    {
        public int IdTitular { get; set; }
        public string Primeironome { get; set; }
        public string Ultimonome { get; set; }
        public string Email { get; set; }
        public int? IdConta { get; set; }

        public virtual Conta IdContaNavigation { get; set; }
    }
}
