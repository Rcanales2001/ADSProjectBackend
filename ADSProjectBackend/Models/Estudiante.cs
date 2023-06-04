using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(28, MinimumLength = 5, ErrorMessage = "El campo {0} debe estar entre 5 y 28 caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo (0) es requerido")]
        [StringLength(50, MinimumLength = -2, ErrorMessage = "El campo {0} debe estar entre 2 y 50 caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo {0} debe estar entre 2 y 50 caracteres")]
        public string Apellidos { get; set; }
    }
}
