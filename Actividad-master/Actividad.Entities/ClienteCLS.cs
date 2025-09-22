using System.ComponentModel.DataAnnotations;                    

namespace Actividad.Entities
{
    public class ClienteCLS
    {
        [Required(ErrorMessage = "El campo Cod. Cliente es obligatorio")]
        [Range(0,int.MaxValue, ErrorMessage = "El valor minimo es 1")]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre Cliente es obligatorio")]
        public string NombreCliente { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar un Representante")]
        public int Num_Empl { get; set; }

        [Required(ErrorMessage = "El campo Limite de Credito es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El limite de credito debe ser un valor numérico positivo")]
        public double LimiteCredito { get; set; }
    }
}