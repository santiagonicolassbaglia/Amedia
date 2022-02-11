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
    public class AgregarAdministradorModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AgregarAdministradorModel(ApplicationDbContext context)
        {
            _context = context;
        }




        [BindProperty]
        public string ErrorMessage { get; set; }


        [BindProperty]
        public tUsers persona { get; set; } = new tUsers();

        [BindProperty]
        public tRol rol { get; set; }

        [BindProperty]
        public int IdRol { get; set; }

        public void OnGet()
        {
            

        }



        public ActionResult OnPostAltaAdministrador()
        {
            tUsers registrarUsuario = new tUsers();

           
            persona.idRol = IdRol;
            persona.snActivo = 1;
            


                if(ValidarAdministrador())
                {  DB.InsertarCliente(persona);
                    return Page();
                }
            

            else
            {
                ModelState.AddModelError("ErrorMessage", "El usuario es incorrecto.");
                return Page();
            }



            return Page();

        }



        public bool ValidarAdministrador()
        {
            bool isValid = true;

            if(persona.Nombre==null || persona.Apellido == null || persona.Contrasenia == null || persona.Documento == null || persona.Usuario == null)
            {
                isValid = false;
            }
                return isValid;
        }



        public bool ValidarString(string auxString)
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
