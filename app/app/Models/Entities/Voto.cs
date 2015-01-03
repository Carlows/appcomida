using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace app.Models.Entities
{
    public class Voto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public VoteType Resultado { get; set; }

        [Required]
        public virtual ApplicationUser Usuario { get; set; }
        [Required]
        public virtual Registro Registro { get; set; }
    }

    public enum VoteType
    {
        Positivo,
        Negativo
    }
}