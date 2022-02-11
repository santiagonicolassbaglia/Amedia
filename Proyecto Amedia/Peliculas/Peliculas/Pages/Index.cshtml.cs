using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PeliculasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        [BindProperty]
        public string ErrorMessage { get; set; }


        [BindProperty]
        public tUsers persona { get; set; }

        tRol rol { get; set; }

        public ActionResult OnPostBtnIngresar_Click(string usuario, string contrasenia)
        {
            string user, pass;

            user = usuario;
            pass = contrasenia;

            if (!ValidarString(user))
            {
                persona = DB.validaUsuario(user, pass);

                if (!(persona is null))
                {
                    if(persona.idRol is 2)
                        { 
                             return RedirectToPage("/Vistas/Cliente/Home");
                        }
                    else
                    {
                        return RedirectToPage("/Vistas/Administrador/HomeAdministrador");
                    }

                  
                }

                else
                {
                    ModelState.AddModelError("ErrorMessage", "El usuario es incorrecto.");
                    return Page();
                }

            }

            return Page();

        }


        public ActionResult OnPostAltaUsuario_Click()
        {
            return RedirectToPage("Vistas/Cliente/AgregarUsuario");
        }



        public static bool ValidarString(string auxString)
        {
            if (String.IsNullOrEmpty(auxString) || auxString.Length < 2)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}