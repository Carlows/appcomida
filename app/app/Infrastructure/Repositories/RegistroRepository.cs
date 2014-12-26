using app.Models;
using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace app.Infrastructure.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly ApplicationDbContext _db;

        public RegistroRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Registro> GetAll()
        {
            return _db.Registros;
        }

        public Registro GetById(int? id)
        {
            if(id != null)
            {
                return _db.Registros.Find(id);
            }
            else
            {
                throw new ArgumentNullException("Id value must be passed to GetById()");
            }
        }

        public IEnumerable<Registro> GetAllBy(Expression<Func<Registro, bool>> predicate)
        {
            if(predicate != null)
            {
                return _db.Registros.Where(predicate);
            }
            else
            {
                throw new ArgumentNullException("A predicate must be passed to GetAllBy to perform filtering");
            }
        }

        public Registro Add(Registro registro)
        {
            if(registro != null)
            {
                _db.Registros.Add(registro);
                _db.SaveChanges();

                return registro;
            }
            else
            {
                throw new ArgumentNullException("A record must be passed as argument");
            }
        }

        public Registro Update(Registro registro)
        {
            if(registro != null)
            {
                _db.Entry(registro).State = EntityState.Modified;
                _db.SaveChanges();

                return registro;
            }
            else
            {
                throw new ArgumentNullException("A record must be passed as argument");
            }
        }

        public void Delete(int? id)
        {
            if(id != null)
            {
                var registro = _db.Registros.Find(id);
                _db.Registros.Remove(registro);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("The id must be passed as argument");
            }
        }
    }
}