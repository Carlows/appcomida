using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models.Entities
{
    public partial class Registro
    {
        public int VoteCount
        {
            get 
            {
                int positivos = Votos.Where(v => v.Resultado == VoteType.Positivo).Count();
                int negativos = Votos.Where(v => v.Resultado == VoteType.Negativo).Count();

                return positivos - negativos;
            }
        }
    }
}