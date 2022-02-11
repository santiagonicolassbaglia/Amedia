using System;
using System.ComponentModel.DataAnnotations;

namespace PeliculasModel
{
    public class tPelicula

       
    {
        public tPelicula()
        {
        }

        public tPelicula(int id, string nombre, int cantidadDisponibleAlquiler, int cantidadDisponibleVenta, decimal precioAlquiler, decimal precioVenta)
        {
            Id = id;
            Nombre = nombre;
            CantidadDisponibleAlquiler = cantidadDisponibleAlquiler;
            CantidadDisponibleVenta = cantidadDisponibleVenta;
            PrecioAlquiler = precioAlquiler;
            PrecioVenta = precioVenta;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        public int CantidadDisponibleAlquiler { get; set; }
        public int CantidadDisponibleVenta { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
