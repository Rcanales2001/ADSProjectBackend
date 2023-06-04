using ADSProjectBackend.DBContext;
using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class CarreraRepositorio : ICarreraRepositorio
    {
        private ApplicationDbContext applicationDbContext;
        public CarreraRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public bool EliminarCarrera(int idValue)
        {
            try
            {
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idValue);
                applicationDbContext.Carreras.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarCarrera(Carrera value)
        {
            try
            {
                applicationDbContext.Carreras.Add(value);
                applicationDbContext.SaveChanges();
                return value.Id;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarCarrera(int idValue, Carrera value)
        {
            try
            {
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idValue);

                applicationDbContext.Entry(item).CurrentValues.SetValues(value);

                applicationDbContext.SaveChanges();

                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Carrera ObtenerCarreraPorId(int idValue)
        {
            try
            {
                return applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Carrera> ObtenerListaCarreras()
        {
            return applicationDbContext.Carreras.ToList();
        }
    }
}
