using ADSProjectBackend.Models;

namespace ADSProjectBackend.Repositories.Interfaces
{
    public interface IGrupoRepositorio
    {
        int InsertarGrupo(Grupo value);
        int ModificarGrupo(int idValue, Grupo value);
        bool EliminarGrupo(int idValue);
        List<Grupo> ObtenerListaGrupos();
        Grupo ObtenerGrupoPorId(int idValue);
    }
}
