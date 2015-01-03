using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.Repositories
{
    public interface IVotoRepository
    {
        Voto Add(Voto voto);
        Voto Update(Voto voto);
    }
}
