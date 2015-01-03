using app.Models;
using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace app.Infrastructure.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly ApplicationDbContext _db;

        public VotoRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public Voto Add(Voto voto)
        {
            if (voto != null)
            {
                _db.Votos.Add(voto);
                _db.SaveChanges();

                return voto;
            }
            else
            {
                throw new ArgumentNullException("A vote must be passed as argument");
            }
        }

        public Voto Update(Voto voto)
        {
            if (voto != null)
            {
                _db.Entry(voto).State = EntityState.Modified;
                _db.SaveChanges();

                return voto;
            }
            else
            {
                throw new ArgumentNullException("A vote must be passed as argument");
            }
        }
    }
}