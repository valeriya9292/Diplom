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

        IEnumerable<TimeLog> FindByUserId(int userId, int week, int year);

        void Delete(int timeLogId);

        int Save(TimeLog timeLog);
    }
}
