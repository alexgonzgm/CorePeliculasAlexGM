using CorePeliculasAlexGM.Data;
using CorePeliculasAlexGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Repositories
{
    public class RepositoryPeliculas : IRepositoryPeliculas
    {
        private ApplicationDbContext context;
        public RepositoryPeliculas(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Genero> GetGeneros()
        {
            return this.context.Generos.ToList();
        }

        public string GetNombregenero(int idgenero)
        {
            string nombregenero = this.context.Generos
                .Where(x => x.IdGenero == idgenero)
                .Select(s => s.NombreGenero)
                .SingleOrDefault();
            return nombregenero;
        }

        public Pelicula GetPeliculaPorId(int idpelicula)
        {
            return this.context.Peliculas.Where(x => x.IdPelicula == idpelicula).SingleOrDefault();
        }

        public List<Pelicula> GetPeliculas()
        {
            return this.context.Peliculas.ToList();
        }

        public List<Pelicula> GetPeliculasCarrito(List<int> listasession )
        {
            List<Pelicula> lista = new List<Pelicula>();
            foreach (var item in listasession)
            {
                Pelicula pelicula = this.GetPeliculaPorId(item);
                lista.Add(pelicula);
            }
            return lista;
        }

        public List<Pelicula> GetPeliculasPorGenero(int idgenero)
        {
            return this.context.Peliculas.Where(x => x.IdGenero == idgenero).ToList();
        }
        
    }
}
