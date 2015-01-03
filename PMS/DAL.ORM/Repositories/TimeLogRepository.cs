using System.Collections.Generic;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Properties.Model;

namespace DAL.ORM.Repositories
{
    public class TimeLogRepository : ITimeLogRepository
    {
        public TimeLog FindById(int id)
        {
            using (var context = new PmsDbContext())
            {
                return context.TimeLogs.FirstOrDefault(it => it.Id == id).ToEntityTimeLog();
            }
        }

        public IEnumerable<TimeLog> FindByUserId(int userId)
        {
            using (var context = new PmsDbContext())
            {
                return context.TimeLogs.Where(it => it.UserId == userId).Select(it => it.ToEntityTimeLog());
            }
        }

        public void Delete(int timeLogId)
        {
            using (var context = new PmsDbContext())
            {
                var timeLog = context.TimeLogs.FirstOrDefault(t => t.Id == timeLogId);
                if (timeLog == null) return;
                context.TimeLogs.Remove(timeLog);
                context.SaveChanges();
            }
        }

        public void Save(TimeLog timeLog)
        {
            using (var context = new PmsDbContext())
            {
                var oldTimeLog = context.TimeLogs.FirstOrDefault(u => u.Id == timeLog.Id);
                if (oldTimeLog != null)
                {
                    context.TimeLogs.Remove(oldTimeLog);
                }
                context.TimeLogs.Add(timeLog.ToOrmTimeLog());
                context.SaveChanges();
            }
        }
    }
}
