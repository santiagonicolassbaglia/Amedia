using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeliculasModel
{
    public class tUsers
    {
        public tUsers()
        {

        }
        public tUsers(string nombre, string apellido, string contrasenia, string usuario, string documento, int idRol, int snActivo)
        {

            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Usuario = usuario;
            Documento = documento;
            this.idRol = idRol;
            this.snActivo = snActivo;
        }

        [Key]
        public int Id { get; set; }


      

        public string Nombre { get; set; }

   
       

        public string Apellido { get; set; }

        public string Contrasenia { get; set; }
  
      
        public string Usuario { get; set; }
     
        public string Documento { get; set; }

  
        public int idRol { get; set; }
        public int snActivo { get; set; }

    }
}
