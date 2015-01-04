using BLL.DomainModel.Entities;
using BLL.DomainModel.Enums;
using ORM.Model;
using ORM.Model.Enums;

namespace DAL.ORM.Convertions
{
    public static class OrmEntityConverter
    {
        public static User ToEntityUser(this OrmUser user)
        {
            return new User()
            {
                Id = user.Id,
                Avatar = user.Avatar,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Phone = user.Phone,
                Role = (Role) user.Role,
                Skype = user.Skype,
                CreationDate = user.CreationDate
            };
        }
        public static OrmUser ToOrmUser(this User user)
        {
            return new OrmUser()
            {
                Id = user.Id,
                Avatar = user.Avatar,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Phone = user.Phone,
                Role = (OrmRole)user.Role,
                Skype = user.Skype,
                CreationDate = user.CreationDate
            };
        }
        public static OrmProject ToOrmProject(this Project project)
        {
            return new OrmProject()
            {
                Id = project.Id,
                Description = project.Description,
                Duration = project.Duration,
                Name = project.Name,
                Progress = project.Progress,
                StartDate = project.StartDate,
                Status = (OrmProjectStatus) project.Status
            };
        }
        public static Project ToEntityProject(this  OrmProject project)
        {
            return new Project()
            {
                Id = project.Id,
                Description = project.Description,
                Duration = project.Duration,
                Name = project.Name,
                Progress = project.Progress,
                StartDate = project.StartDate,
                Status = (ProjectStatus)project.Status
            };
        }
        public static OrmComment ToOrmComment(this Comment comment)
        {
            return new OrmComment()
            {
                Id = comment.Id,
                CreationDate = comment.CreationDate,
                Description = comment.Description,
                TaskId = comment.TaskId,
                UserId = comment.UserId
            };
        }
        public static Comment ToEntityComment(this OrmComment comment)
        {
            return new Comment()
            {
                Id = comment.Id,
                CreationDate = comment.CreationDate,
                Description = comment.Description,
                TaskId = comment.TaskId,
                UserId = comment.UserId
            };
        }
        public static Task ToEntityTask(this OrmTask task)
        {
            return new Task()
            {
                Id = task.Id,
                CreatorId = task.CreatorId,
                Description = task.Description,
                Duration = task.Duration,
                Name = task.Name,
                Progress = task.Progress,
                ProjectId = task.ProjectId,
                StartDate = task.StartDate,
                Status = (ProjectStatus) task.Status
            };
        }
        public static OrmTask ToOrmTask(this Task task)
        {
            return new OrmTask()
            {
                Id = task.Id,
                CreatorId = task.CreatorId,
                Description = task.Description,
                Duration = task.Duration,
                Name = task.Name,
                Progress = task.Progress,
                ProjectId = task.ProjectId,
                StartDate = task.StartDate,
                Status = (OrmProjectStatus)task.Status
            };
        }

        public static TimeLog ToEntityTimeLog(this OrmTimeLog timeLog)
        {
            return new TimeLog()
            {
                Id = timeLog.Id,
                HoursInMonday = timeLog.HoursInMonday,
                HoursInTuesday = timeLog.HoursInThursday,
                HoursInWednesday = timeLog.HoursInWednesday,
                HoursInThursday = timeLog.HoursInThursday,
                HoursInFriday = timeLog.HoursInFriday,
                HoursInSaturday = timeLog.HoursInSaturday,
                HoursInSunday = timeLog.HoursInSunday,
                Title = timeLog.Title,
                UserId = timeLog.UserId,
                Week = timeLog.Week,
                Year = timeLog.Year
                
            };
        }
        public static OrmTimeLog ToOrmTimeLog(this TimeLog timeLog)
        {
            return new OrmTimeLog()
            {
                Id = timeLog.Id,
                HoursInMonday = timeLog.HoursInMonday,
                HoursInTuesday = timeLog.HoursInThursday,
                HoursInWednesday = timeLog.HoursInWednesday,
                HoursInThursday = timeLog.HoursInThursday,
                HoursInFriday = timeLog.HoursInFriday,
                HoursInSaturday = timeLog.HoursInSaturday,
                HoursInSunday = timeLog.HoursInSunday,
                Title = timeLog.Title,
                UserId = timeLog.UserId,
                Week = timeLog.Week,
                Year = timeLog.Year
            };
        }

        public static ProjectMember ToEntityProjectMember(this OrmProjectMember projectMember)
        {
            return new ProjectMember()
            {
                Id = projectMember.Id,
                ProjectId = projectMember.ProjectId,
                UserId = projectMember.UserId
            };
        }
        public static OrmProjectMember ToOrmProjectMember(this ProjectMember projectMember)
        {
            return new OrmProjectMember()
            {
                Id = projectMember.Id,
                ProjectId = projectMember.ProjectId,
                UserId = projectMember.UserId
            };
        }
    }
}
