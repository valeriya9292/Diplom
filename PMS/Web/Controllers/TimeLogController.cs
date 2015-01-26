using System;
using System.Globalization;
using System.Web.Mvc;
using BLL.DomainModel.Entities;
using BLL.Services;

namespace Web.Controllers
{
    public class TimeLogController : BaseController
    {
        private readonly TimeLogService service;
        private readonly UserService userService;

        public ActionResult Index()
        {
            return View();
        }

        public TimeLogController(TimeLogService service, UserService userService)
        {
            this.service = service;
            this.userService = userService;
        }

        public ActionResult GetTimelogs(DateTime? startDate)
        {
            var weekNumber = WeekOfYearISO8601(startDate ?? DateTime.Today);
            var timelogs = service.FindTimeLogsByUserId(CurrentUser.Id, weekNumber, DateTime.Today.Year);

            return Json(new { timelogs }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(TimeLog timelog, DateTime startDate)
        {
            try
            {
                timelog.UserId = CurrentUser.Id;
                timelog.Week = WeekOfYearISO8601(startDate);
                timelog.Year = startDate.Year;

                var savedTimelogId = service.SaveTimeLog(timelog);
                var savedTimelog = service.FindTimeLogById(savedTimelogId);

                return Json(savedTimelog, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! Timelog was not saved =(" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int id)
        {
            service.DeleteTimeLog(id);
            return Json(new { id }, JsonRequestBehavior.AllowGet);
        }

        private static int WeekOfYearISO8601(DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private User CurrentUser
        {
            get { return userService.FindUserByLogin(User.Identity.Name); }
        }
    }
}
