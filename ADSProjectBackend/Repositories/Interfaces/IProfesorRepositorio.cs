using ADSProjectBackend.Models;

namespace ADSProjectBackend.Repositories.Interfaces
{
    public interface IProfesorRepositorio
    {
        int InsertarProfesor(Profesor value);
        int ModificarProfesor(int idValue, Profesor value);
        bool EliminarProfesor(int idValue);
        List<Profesor> ObtenerListaProfesores();
        Profesor ObtenerProfesorPorId(int idValue);
    }
}
