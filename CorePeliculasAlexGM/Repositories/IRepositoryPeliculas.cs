using CorePeliculasAlexGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Repositories
{
    public interface IRepositoryPeliculas
    {
        List<Genero> GetGeneros();
        string GetNombregenero(int idgenero);
        List<Pelicula> GetPeliculas();
        List<Pelicula> GetPeliculasPorGenero(int idgenero);
        Pelicula GetPeliculaPorId(int idpelicula);

        List<Pelicula> GetPeliculasCarrito(List<int> listasession);
    }
}
