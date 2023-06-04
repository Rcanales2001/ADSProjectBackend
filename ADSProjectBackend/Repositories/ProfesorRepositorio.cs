using ADSProjectBackend.DBContext;
using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class ProfesorRepositorio : IProfesorRepositorio
    {
        private ApplicationDbContext applicationDbContext;
        public ProfesorRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public bool EliminarProfesor(int idValue)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.Id == idValue);
                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarProfesor(Profesor value)
        {
            try
            {
                applicationDbContext.Profesores.Add(value);
                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarProfesor(int idValue, Profesor value)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.Id == idValue);

                applicationDbContext.Entry(item).CurrentValues.SetValues(value);

                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Profesor ObtenerProfesorPorId(int idValue)
        {
            try
            {
                return applicationDbContext.Profesores.SingleOrDefault(x => x.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ObtenerListaProfesores()
        {
            return applicationDbContext.Profesores.ToList();
        }
    }
}
