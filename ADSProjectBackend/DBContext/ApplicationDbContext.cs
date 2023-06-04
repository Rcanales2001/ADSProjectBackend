using ADSProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProjectBackend.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        //Con un DbSet se indica a EFC cuales tables quiero en la base de datos

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
