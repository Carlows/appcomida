using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models.ViewModels
{
    public class RegistroViewModel
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Direccion Direccion { get; set; }
    }
}