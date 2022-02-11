using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasModel
{
    public class tGenero
    {
       
        public int IdGenero { get; set; }

        public Egenero eGenero { get; set; }


        public enum Egenero { Accion = 1, Comedia = 2, Drama = 3, Terror = 4 }
    }
}
