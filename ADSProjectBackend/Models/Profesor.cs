using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El campo {0} debe estar entre 2 y 100 caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El campo {0} debe estar entre 2 y 100 caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo valido")]
        public string Email { get; set; }
    }
}
