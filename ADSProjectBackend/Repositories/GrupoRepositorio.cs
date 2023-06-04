using ADSProjectBackend.DBContext;
using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private ApplicationDbContext applicationDbContext;

        public GrupoRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public bool EliminarGrupo(int idValue)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.Id == idValue);
                applicationDbContext.Grupos.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarGrupo(Grupo value)
        {
            try
            {
                applicationDbContext.Grupos.Add(value);
                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarGrupo(int idValue, Grupo value)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.Id == idValue);

                applicationDbContext.Entry(item).CurrentValues.SetValues(value);

                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupo ObtenerGrupoPorId(int idValue)
        {
            try
            {
                return applicationDbContext.Grupos.SingleOrDefault(x => x.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupo> ObtenerListaGrupos()
        {
            return applicationDbContext.Grupos.ToList();
        }
    }
}
