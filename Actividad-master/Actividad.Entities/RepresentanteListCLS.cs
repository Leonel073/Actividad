using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad.Entities
{
    public class RepresentanteListCLS
    {
        public int Num_Empl {  get; set; }
        public string Nombre { get; set; } = null!;
        public int Edad { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime FechaContrato { get; set; }
        public double Cuota { get; set; }
        public int Ventas { get; set; }
        public string nombreJefe { get; set; } = string.Empty;
        public string nombreSucursal { get; set; } = string.Empty;

    }
}
