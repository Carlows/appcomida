using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace app.Infrastructure.Repositories
{
    public interface IRegistroRepository
    {
        IEnumerable<Registro> GetAll();
        Registro GetById(int? id);
        IEnumerable<Registro> GetAllBy(Expression<Func<Registro, bool>> predicate);
        Registro Add(Registro registro);
        Registro Update(Registro registro);
        void Delete(int? id);
    }
}