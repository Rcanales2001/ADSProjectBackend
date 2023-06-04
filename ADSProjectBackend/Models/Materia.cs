using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(28, MinimumLength = 5, ErrorMessage = "El campo {0} debe estar entre 5 y 28 caracteres")]
        public string Nombre { get; set; }
    }
}
