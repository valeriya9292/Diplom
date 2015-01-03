using System.Collections.Generic;
using BLL.DomainModel.Entities;
using BLL.Repositories;

namespace BLL.Services
{
    public class TimeLogService
    {
        private readonly ITimeLogRepository repository;

        public TimeLogService(ITimeLogRepository repository)
        {
            this.repository = repository;
        }

        TimeLog FindTimeLogById(int id)
        {
            return repository.FindById(id);
        }

        IEnumerable<TimeLog> FindTimeLogsByUserId(int userId)
        {
            return repository.FindByUserId(userId);
        }

        void DeleteTimeLog(int timeLogId)
        {
            repository.Delete(timeLogId);
        }

        void SaveTimeLog(TimeLog timeLog)
        {
            repository.Save(timeLog);
        }
    }
}
