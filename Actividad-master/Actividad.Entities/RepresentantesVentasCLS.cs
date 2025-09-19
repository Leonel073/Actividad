using System.ComponentModel.DataAnnotations;                    

namespace Actividad.Entities
{
    public class RepresentantesVentasCLS
    {
        [Required(ErrorMessage = "El campo Num. Empleado es obligatorio")]
        [Range(0,int.MaxValue, ErrorMessage = "El valor minimo es 1")]
        public int Num_Empl { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo Edad es obligatorio")]
        [Range(18, 100, ErrorMessage = "La Edad debe ser mayor o igual a 18")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El campo Cargo es obligatorio")]
        public string Cargo { get; set; } = null!;
        [Required(ErrorMessage = "La Fecha de Contrato es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaContrato { get; set; }
        [Required(ErrorMessage = "El campo Cuota es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "Cuota debe ser un valor numérico positivo")]
        public double Cuota { get; set; }
        [Required(ErrorMessage = "El campo Ventas es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Ventas debe ser un valor numérico positivo")]
        public int Ventas { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Debe de seleccionar un Jefe")]
        public int idJefe { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar una Sucursal")]
        public int idSucursal { get; set; }
    }
}