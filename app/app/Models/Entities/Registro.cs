using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.Models.Entities
{
    // Registro de lo que envian los usuarios, esto une la direccion y el producto
    public partial class Registro
    {
        public Registro()
        {
            Creado = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime Creado { get; set; }

        public virtual Direccion Direccion { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual List<Voto> Votos { get; set; }
    }
}