using app.Infrastructure.Repositories;
using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace app.Infrastructure.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _db;

        public RegistroService(IRegistroRepository repo)
        {
            _db = repo;
        }

        public IEnumerable<Registro> GetAllRecords()
        {
            return _db.GetAll().ToList();
        }

        public Registro FindRecordById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> FindRecordsByCity(string city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> FindRecordsByState(string state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> FindRecordsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> FindRecordsBy(Expression<Func<Registro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Registro CreateRecord(Models.ViewModels.RegistroViewModel model)
        {
            throw new NotImplementedException();
        }

        public Registro UpdateRecord(Models.ViewModels.RegistroViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecord(int? id)
        {
            throw new NotImplementedException();
        }
    }
}