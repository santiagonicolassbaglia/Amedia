using Microsoft.AspNetCore.Mvc;
using Peliculas.Data;
using PeliculasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.Pages.Controlador
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<tPelicula> listaPeliculas = _context.Pelicula;
                return View();
        }
    }
}
