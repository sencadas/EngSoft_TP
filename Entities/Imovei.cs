using System;
using System.Collections.Generic;

#nullable disable

namespace TP_ES2.Entities
{
    public partial class Imovei
    {
        public int IdImovel { get; set; }
        public string Designacao { get; set; }
        public string Localizacao { get; set; }
        public double Valordoimovel { get; set; }
        public double Valorderenda { get; set; }
        public double Valormensalcondominio { get; set; }
        public double Valoranualdespesas { get; set; }
    }
}
