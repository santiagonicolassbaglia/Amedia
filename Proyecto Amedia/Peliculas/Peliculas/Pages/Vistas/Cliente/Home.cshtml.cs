using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeliculasModel;

namespace Peliculas.Pages.Vistas.Cliente
{
    public class HomeModel : PageModel
    {
         
        [BindProperty]
        public tPelicula pelicula { get; set; }

     
        [BindProperty]
        public tGeneroPelicula generoPelicula { get; set; }


        [BindProperty]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string MensajeOk { get; set; }



        public void OnGet()
        {
        }






        public ActionResult OnPostAltaPelicula()
        {

            if (ValidarPelicula())
            {
                ModelState.AddModelError("MensajeOk", "Pelicula agregada Correctamente.");
                DB.InsertarPelicula(pelicula);
                DB.InsertarGeneroPelicula(generoPelicula);
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

            if (pelicula.Nombre == null || pelicula.CantidadDisponibleAlquiler == 0 || pelicula.CantidadDisponibleVenta == 0 || pelicula.PrecioAlquiler == 0)
            {
                isValid = false;
            }
            return isValid;
        }




    }
}
