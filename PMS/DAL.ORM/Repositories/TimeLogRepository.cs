using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Model;

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

        public IEnumerable<TimeLog> FindByUserId(int userId, int week, int year)
        {
            using (var context = new PmsDbContext())
            {
                return context.TimeLogs.AsEnumerable()
                    .Where(it => it.UserId == userId && it.Week == week && it.Year == year)
                    .Select(it => it.ToEntityTimeLog()).ToList();
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

        public int Save(TimeLog timeLog)
        {
            using (var context = new PmsDbContext())
            {
                OrmTimeLog savedTimelog;
                var oldTimeLog = context.TimeLogs.FirstOrDefault(u => u.Id == timeLog.Id);
                if (oldTimeLog != null)
                {
                    savedTimelog = oldTimeLog;
                    oldTimeLog.HoursInMonday = timeLog.HoursInMonday;
                    oldTimeLog.HoursInTuesday = timeLog.HoursInThursday;
                    oldTimeLog.HoursInWednesday = timeLog.HoursInWednesday;
                    oldTimeLog.HoursInThursday = timeLog.HoursInThursday;
                    oldTimeLog.HoursInFriday = timeLog.HoursInFriday;
                    oldTimeLog.HoursInSaturday = timeLog.HoursInSaturday;
                    oldTimeLog.HoursInSunday = timeLog.HoursInSunday;
                    oldTimeLog.Title = timeLog.Title;

                    //oldTimeLog.Week = timeLog.Week;
                    //oldTimeLog.Year = timeLog.Year;

                    context.Entry(oldTimeLog).State = EntityState.Modified;
                }
                else
                {
                    savedTimelog = context.TimeLogs.Add(timeLog.ToOrmTimeLog());
                }
                context.SaveChanges();
                return savedTimelog.Id;
            }          
        }
    }
}
