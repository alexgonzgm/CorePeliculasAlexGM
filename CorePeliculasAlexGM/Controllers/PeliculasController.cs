using CorePeliculasAlexGM.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePeliculasAlexGM.Extensions;

namespace CorePeliculasAlexGM.Controllers
{
    public class PeliculasController : Controller
    {
        private IRepositoryPeliculas repository;
        public PeliculasController(IRepositoryPeliculas repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MostrarPeliculasGenero(int idgenero)
        {
            string nombregenero = this.repository.GetNombregenero(idgenero);
            ViewData["GENERO"] = nombregenero;
            //TempData["IDGENERO"] = idgenero;
            return View(this.repository.GetPeliculasPorGenero(idgenero));
        }

        public IActionResult Details(int idpelicula )
        {
  
            return View(this.repository.GetPeliculaPorId(idpelicula));
        }

        public IActionResult alamcenarEnSession(int? idpeliculacompra , int ? idpeliculagenero)
        {
            
            if (idpeliculacompra != null)
            {
                List<int> sessionidpeliculas;
                if (HttpContext.Session.GetObject<List<int>>("IDS")== null)
                {
                    sessionidpeliculas = new List<int>();
                }
                else
                {
                    sessionidpeliculas = HttpContext.Session.GetObject<List<int>>("IDS");
                }
                if (sessionidpeliculas.Contains(idpeliculacompra.Value) == false)
                {
                    sessionidpeliculas.Add(idpeliculacompra.GetValueOrDefault());
                    HttpContext.Session.SetObject("IDS", sessionidpeliculas);
                }
               
                
            }
            int id = idpeliculagenero.Value;
           return RedirectToAction("MostrarPeliculasGenero", new { idgenero  = id});
        }
        public IActionResult Compra(int ? ideliminar)
        {
            
            List<int> listacompra = HttpContext.Session.GetObject<List<int>>("IDS");
            if (ideliminar != null)
            {
                listacompra.Remove(ideliminar.Value);
                HttpContext.Session.SetObject("IDS", listacompra);


            }

            return View(this.repository.GetPeliculasCarrito(listacompra));
        }
        
    }
}
