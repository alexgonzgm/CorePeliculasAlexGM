using CorePeliculasAlexGM.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Models
{
    public class MenuGenerosViewComponent : ViewComponent
    {
        private IRepositoryPeliculas repository;
        public MenuGenerosViewComponent(IRepositoryPeliculas repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = this.repository.GetGeneros();
            return View(generos);
        }
    }
}
