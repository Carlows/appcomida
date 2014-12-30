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
        IEnumerable<Registro> GetAllRecords();
        IEnumerable<Registro> GetRecordsDescending();
        Registro FindRecordById(int? id);
        IEnumerable<Registro> FindRecordsByCity(string city);
        IEnumerable<Registro> FindRecordsByState(string state);
        IEnumerable<Registro> FindRecordsByDay(DateTime day);
        IEnumerable<Registro> FindRecordsBy(Expression<Func<Registro, bool>> predicate);
        Registro CreateRecord(RegistroViewModel model);
        Registro UpdateRecord(RegistroViewModel model);
        bool DeleteRecord(int? id);
    }
}
