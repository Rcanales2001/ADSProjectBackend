using ADSProjectBackend.Models;

namespace ADSProjectBackend.Repositories.Interfaces
{
    public interface IMateriaRepositorio
    {
        int InsertarMateria(Materia value);
        int ModificarMateria(int idValue, Materia value);
        bool EliminarMateria(int idValue);
        List<Materia> ObtenerListaMaterias();
        Materia ObtenerMateriaPorId(int idValue);
    }
}
