using app.Models.Entities;
using app.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.Services
{
    public interface IRegistroService
    {
        IEnumerable<RegistroViewModel> GetAllRecords();
        IEnumerable<RegistroViewModel> GetRecordsDescending();
        RegistroViewModel FindRecordById(int? id);
        IEnumerable<RegistroViewModel> FindRecordsByCity(string city);
        IEnumerable<RegistroViewModel> FindRecordsByState(string state);
        IEnumerable<RegistroViewModel> FindRecordsByDay(DateTime day);
        IEnumerable<RegistroViewModel> FindRecordsBy(Expression<Func<Registro, bool>> predicate);
        RegistroViewModel CreateRecord(RegistroViewModel model);
        RegistroViewModel UpdateRecord(RegistroViewModel model);
        Task<Voto> AddOrUpdateVote(int registroID, string userID, bool typeofvote);
        bool DeleteRecord(int? id);
    }
}
