using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Amenzas
    {
        [Key]
        public int AmenazasId { get; set; }

        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public String Amenaza { get; set; }

        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public String Control { get; set; }

        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public String Impacto { get; set; }

        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public String Riesgo { get; set; }

        [Required(ErrorMessage = "El campo seleccione activo es obligatorio.")]
        public String ActivosId { get; set; }
        public Activos? Activos { get; set; }

        [Required(ErrorMessage = "El campo seleccione activo es obligatorio.")]
        public String DimensionesId { get; set; }
        public Activos? Dimensiones { get; set; }
    }
}
