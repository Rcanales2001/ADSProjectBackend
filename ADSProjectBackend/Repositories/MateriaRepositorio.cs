using ADSProjectBackend.DBContext;
using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private ApplicationDbContext applicationDbContext;

        public MateriaRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public bool EliminarMateria(int idValue)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.Id == idValue);
                applicationDbContext.Materias.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarMateria(Materia value)
        {
            try
            {
                applicationDbContext.Materias.Add(value);
                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarMateria(int idValue, Materia value)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.Id == idValue);

                applicationDbContext.Entry(item).CurrentValues.SetValues(value);

                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materia> ObtenerListaMaterias()
        {
            return applicationDbContext.Materias.ToList();
        }

        public Materia ObtenerMateriaPorId(int idValue)
        {
            try
            {
                return applicationDbContext.Materias.SingleOrDefault(x => x.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
