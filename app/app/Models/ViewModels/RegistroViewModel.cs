using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.Models.ViewModels
{
    public class RegistroViewModel
    {
        public int Id { get; set; }
        public ProductoViewModel Producto { get; set; }
        public DireccionViewModel Direccion { get; set; }
    }

    public class ProductoViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public bool? Regulado { get; set; }
    }

    public class DireccionViewModel
    {
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string DireccionLocal { get; set; }
        [Required]
        public string Local { get; set; }
        [Required]
        public GoogleMapPoint Position { get; set; }
    }
}