using System;
using System.Collections.Generic;

namespace NetEFPruebaInicial.Data.Entidades
{
    public partial class Especie
    {
        public int IdEspecie { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? PesoPromedio { get; set; }
        public int? EdadPromedio { get; set; }
        public int IdTipoEspecie { get; set; }

        public virtual Tipoespecie IdTipoEspecieNavigation { get; set; } = null!;
    }
}
