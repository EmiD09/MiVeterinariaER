using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiVeterinaria.Web.Data.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
                
        }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<TipoMascota> TipoMascotas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<TipoServicio> TipoServicios { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
