using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peliculas.Data;
using PeliculasModel;

namespace Peliculas.Pages.Vistas.Administrador
{
    public class HomeAdministradorModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HomeAdministradorModel(ApplicationDbContext context)
        {
            _context = context;
        }


        

        [BindProperty]
        public string ErrorMessage { get; set; }


        [BindProperty]
        public tPelicula pelicula { get; set; }

       
        public tRol rol { get; set; }

        [BindProperty]
        public List<tPelicula> Peliculas { get; set; }



        public ActionResult OnGet()
        {
            Peliculas = DB.GetPeliculas();
            //pelicula = DB.GetPeliculasPorId(idPelicula);
            return Page();
        }



        public ActionResult OnPostAgregarPelicula()
        {
            return RedirectToPage("/Vistas/Administrador/AltaPelicula");
        }


        public ActionResult OnPostAltaAdministrador()
        {
            return RedirectToPage("/Vistas/Administrador/AgregarAdministrador");
        }
        
        public ActionResult OnPostEditar(int idPelicula)
        {
            return RedirectToPage("/Vistas/Administrador/EditarPelicula", new { IdPelicula = idPelicula });
        } 
        
        public ActionResult OnPostEliminar(int idPelicula)
        {
            pelicula.Id = idPelicula;

            DB.EliminarPeliculas(pelicula);
            ModelState.AddModelError("MensajeOk", "Pelicula eliminada Correctamente.");
            Peliculas = DB.GetPeliculas();
            return Page();

        }



    }
}
