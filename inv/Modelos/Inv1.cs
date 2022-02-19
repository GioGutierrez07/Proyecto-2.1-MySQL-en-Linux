using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Inv1
    {
        public int IdInventario { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string Fecha { get; set; }
        public string TipoAdquisio { get; set; }
        public string obserbaciones { get; set; }

        public int IdArea { get; set; }
    }
}
