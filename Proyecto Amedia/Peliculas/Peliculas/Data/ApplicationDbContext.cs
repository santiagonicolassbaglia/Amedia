using Microsoft.EntityFrameworkCore;
using PeliculasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<tUsers> Persona { get; set; }
        public DbSet<tPelicula> Pelicula { get; set; }
        public DbSet<tRol> Rols { get; set; }
        public DbSet<tGeneroPelicula> GeneroPeliculas { get; set; }
        public DbSet<tGenero> Generos { get; set; }
       
    }
}
