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

        public TimeLog FindTimeLogById(int id)
        {
            return repository.FindById(id);
        }

        public IEnumerable<TimeLog> FindTimeLogsByUserId(int userId, int week, int year)
        {
            return repository.FindByUserId(userId, week, year);
        }

        public void DeleteTimeLog(int timeLogId)
        {
            repository.Delete(timeLogId);
        }

        public int SaveTimeLog(TimeLog timeLog)
        {
            return repository.Save(timeLog);
        }
    }
}
