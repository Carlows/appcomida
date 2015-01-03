using app.Infrastructure.Repositories;
using app.Models.Entities;
using app.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace app.Infrastructure.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _db;
        private readonly IVotoRepository _dbvotes;
        private readonly IAuthRepository _users;

        public RegistroService(IRegistroRepository repo, IVotoRepository votesRepo, IAuthRepository userRepo)
        {
            _db = repo;
            _dbvotes = votesRepo;
            _users = userRepo;
        }

        public IEnumerable<RegistroViewModel> GetAllRecords()
        {
            var model = Mapper.Map<List<Registro>, List<RegistroViewModel>>(_db.GetAll().ToList());

            return model;
        }

        public IEnumerable<RegistroViewModel> GetRecordsDescending()
        {
            var model = Mapper.Map<List<Registro>, List<RegistroViewModel>>(_db.GetAll().OrderByDescending(x => x.Creado).ToList());

            return model;
        }

        public RegistroViewModel FindRecordById(int? id)
        {
            var model = Mapper.Map<Registro, RegistroViewModel>(_db.GetById(id));

            return model;
        }

        public IEnumerable<RegistroViewModel> FindRecordsByCity(string city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroViewModel> FindRecordsByState(string state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroViewModel> FindRecordsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroViewModel> FindRecordsBy(Expression<Func<Registro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RegistroViewModel CreateRecord(RegistroViewModel model)
        {
            Registro regMapper = Mapper.Map<RegistroViewModel, Registro>(model);

            var addedRecord = Mapper.Map<Registro, RegistroViewModel>(_db.Add(regMapper));

            return addedRecord;
        }

        public RegistroViewModel UpdateRecord(RegistroViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecord(int? id)
        {
            throw new NotImplementedException();
        }


        public async Task<Voto> AddOrUpdateVote(int registroID, string userID, bool typeofvote)
        {
            var user = await _users.FindUserByName(userID);

            if(user == null)
            {                
                throw new KeyNotFoundException("Cannot find user");
            }

            var registro = _db.GetById(registroID);

            if(registro == null)
            {
                throw new ArgumentException("Cannot find record");
            }

            var voto = registro.Votos.Where(v => v.Usuario.Id == user.Id).SingleOrDefault();
            VoteType tipovoto = typeofvote == true ? VoteType.Positivo : VoteType.Negativo;

            if(voto == null)
            {
                Voto newVote = new Voto()
                {
                    Resultado = tipovoto,
                    Usuario = user,
                    Registro = registro
                };

                _dbvotes.Add(newVote);

                return newVote;
            }
            else
            {
                voto.Resultado = tipovoto;

                _dbvotes.Update(voto);

                return voto;
            }
        }
    }
}