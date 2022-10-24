using System;
using System.Collections.Generic;

namespace NetEFPruebaInicial.Data.Entidades
{
    public partial class Tipoespecie
    {
        public Tipoespecie()
        {
            Especies = new HashSet<Especie>();
        }

        public int IdTipoEspecie { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Especie> Especies { get; set; }
    }
}
