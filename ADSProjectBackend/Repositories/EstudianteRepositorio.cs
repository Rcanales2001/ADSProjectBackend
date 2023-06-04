using ADSProjectBackend.DBContext;
using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class EstudianteRepositorio : IEstudianteRepositorio
    {
        private ApplicationDbContext applicationDbContext;
        public EstudianteRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public bool EliminarEstudiante(int idValue)
        {
            try
            {
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.Id == idValue);
                applicationDbContext.Estudiantes.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }      
        }

        public int InsertarEstudiante(Estudiante value)
        {
            try
            {
                applicationDbContext.Estudiantes.Add(value);
                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarEstudiante(int idValue, Estudiante value)
        {
            try
            {
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.Id == idValue);

                applicationDbContext.Entry(item).CurrentValues.SetValues(value);

                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante ObtenerEstudiantePorId(int idValue)
        {
            try
            {
                return applicationDbContext.Estudiantes.SingleOrDefault(x => x.Id == idValue);

            }
            catch (Exception)
            {

                throw;
            }       
        }

        public List<Estudiante> ObtenerListaEstudiantes()
        {
            return applicationDbContext.Estudiantes.ToList();
        }
    }
}
