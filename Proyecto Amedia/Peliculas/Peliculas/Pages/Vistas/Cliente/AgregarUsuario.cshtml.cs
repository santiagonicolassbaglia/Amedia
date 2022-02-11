using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas.Data;
using PeliculasModel;

namespace Peliculas.Pages.Vistas.Cliente
{
    public class AgregarUsuarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AgregarUsuarioModel(ApplicationDbContext context)
        {
            _context = context;
        }




        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public string MensajeOk { get; set; }


        [BindProperty]
        public tUsers persona { get; set; } = new tUsers();

        [BindProperty]
        public tRol rol { get; set; }

        [BindProperty]
        public int IdRol { get; set; }

        public void OnGet()
        {
            

        }



        public ActionResult OnPostAltaUsuario()
        {
           
            persona.idRol = 2;
            persona.snActivo = 1;
          
            if (ValidarUsuario())
            {
                ModelState.AddModelError("MensajeOk", "Usuario Agregado Correctamente.");
                DB.InsertarCliente(persona);
                return Page();
            }


            else
            {
                ModelState.AddModelError("ErrorMessage", "El usuario es incorrecto.");
                return Page();
            }



            return Page();

        }




        public bool ValidarUsuario()
        {
            bool isValid = true;

            if (persona.Nombre == null || persona.Apellido == null || persona.Contrasenia == null || persona.Documento == null || persona.Usuario == null|| persona.idRol== null)
            {
                isValid = false;
            }
            return isValid;
        }




        public ActionResult OnPostAltaAdministrador()
        {
            return RedirectToPage("/Vistas/Administrador/AgregarAdministrador");
        }
        public ActionResult OnPostVolver()
        {
            return RedirectToPage("/Index");
        }


      

    }
}
