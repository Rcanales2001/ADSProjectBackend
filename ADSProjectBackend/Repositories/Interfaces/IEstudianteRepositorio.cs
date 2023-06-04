using ADSProjectBackend.Models;

namespace ADSProjectBackend.Repositories.Interfaces
{
    public interface IEstudianteRepositorio
    {
        int InsertarEstudiante(Estudiante value);
        int ModificarEstudiante(int idValue, Estudiante value);
        bool EliminarEstudiante(int idValue);
        List<Estudiante> ObtenerListaEstudiantes();
        Estudiante ObtenerEstudiantePorId(int idValue);
    }
}
