using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad.Entities
{
    public class SucursalCLS
    {
        [Required(ErrorMessage = "El campo Cod. de Sucursal es obligatorio")]
        public int idSucursal { get; set; }

        [Required(ErrorMessage = "El campo ciudad es obligatorio")]
        public string ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Region es obligatorio")]
        public string Region { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar un Representante")]
        public int Num_Empl { get; set; }

        [Required(ErrorMessage = "El campo Region es obligatorio")]
        public string ObjetivoVenta { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Ventas Reeales es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Ventas Reales debe ser un valor numérico positivo")]
        public int VentasReales { get; set; }

    }
}
