using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas.Data;
using PeliculasModel;

namespace Peliculas.Pages.Vistas.Administrador
{
    public class AltaPeliculaModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AltaPeliculaModel(ApplicationDbContext context)
        {
            _context = context;
        }




        [BindProperty]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string MensajeOk { get; set; }


        [BindProperty]
        public tPelicula pelicula { get; set; } /*= new tPelicula();*/



        public tRol rol { get; set; }

        [BindProperty]
        public List<tPelicula> Peliculas { get; set; }

        public void OnGet()
        {

        }


        public ActionResult OnPostAltaPelicula()
        { 

            if (ValidarPelicula())
            {
                ModelState.AddModelError("MensajeOk", "Pelicula agregada Correctamente.");
                DB.InsertarPelicula(pelicula);
                return Page();
            }


            else
            {
                ModelState.AddModelError("ErrorMessage", "La pelicula es incorrecta.");
                return Page();
            }



            return Page();

        }




        public bool ValidarPelicula()
        {
            bool isValid = true;

            if (pelicula.Nombre == null || pelicula.CantidadDisponibleAlquiler == 0 || pelicula.CantidadDisponibleVenta == 0 || pelicula.PrecioAlquiler== 0 )
            {
                isValid = false;
            }
            return isValid;
       
        
        }






    }
}
