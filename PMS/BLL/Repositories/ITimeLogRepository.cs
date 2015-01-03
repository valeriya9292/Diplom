using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DomainModel.Entities;

namespace BLL.Repositories
{
    public interface ITimeLogRepository
    {
        //todo:remove unused
        TimeLog FindById(int id);

        IEnumerable<TimeLog> FindByUserId(int userId);

        void Delete(int timeLogId);

        void Save(TimeLog timeLog);
    }
}
