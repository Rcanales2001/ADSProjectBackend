using ADSProjectBackend.Models;

namespace ADSProjectBackend.Repositories.Interfaces
{
    public interface ICarreraRepositorio
    {
        int InsertarCarrera(Carrera value);
        int ModificarCarrera(int idValue, Carrera value);
        bool EliminarCarrera(int idValue);
        List<Carrera> ObtenerListaCarreras();
        Carrera ObtenerCarreraPorId(int idValue);
    }
}
