using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(28, MinimumLength = 5, ErrorMessage = "El campo {0} debe estar entre 5 y 28 caracteres")]
        public string CodigoCarrera { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El campo {0} debe estar entre 5 y 100 caracteres")]
        public string NombreCarrera { get; set; }
    }
}
