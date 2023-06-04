using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Anio { get; set; }
    }
}
