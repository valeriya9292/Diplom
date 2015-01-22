using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Model;
using ORM.Model.Enums;

namespace DAL.ORM.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User FindById(int id)
        {
            using (var context = new PmsDbContext())
            {
                return context.Users.FirstOrDefault(it => it.Id == id).ToEntityUser();
            }
        }

        public User FindUserByLogin(string login)
        {
            using (var context = new PmsDbContext())
            {
                return context.Users.FirstOrDefault(it => it.Login == login).ToEntityUser();
            }
        }

        public IEnumerable<User> FindAll()
        {
            using (var context = new PmsDbContext())
            {
                return context.Users.AsEnumerable().Select(it => it.ToEntityUser()).ToList();
            }
        }

        public IEnumerable<User> FindByProjectId(int projectId)
        {
            using (var context = new PmsDbContext())
            {
                var userIds = context.ProjectMembers.Where(it => it.ProjectId == projectId).Select(it => it.UserId);
                return context.Users.AsEnumerable().Where(it => userIds.Contains(it.Id)).Select(it => it.ToEntityUser()).ToList();
            }
        }

        public void Delete(int userId)
        {
            using (var context = new PmsDbContext())
            {
                var user = context.Users.FirstOrDefault(f => f.Id == userId);
                if (user == null) return;
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void Save(User user)
        {
            using (var context = new PmsDbContext())
            {
                var oldUser = context.Users.FirstOrDefault(u => u.Login == user.Login);
                if (oldUser != null)
                {
                    oldUser.FirstName = user.FirstName;
                    oldUser.LastName = user.LastName;
                    oldUser.Phone = user.Phone;
                    oldUser.Skype = user.Skype;
                    oldUser.Avatar = user.Avatar ?? oldUser.Avatar;
                    oldUser.Birthday = user.Birthday;
                    oldUser.Email = user.Email;
                    oldUser.Role = (OrmRole) user.Role;
                    if(!string.IsNullOrEmpty(user.Password))
                        oldUser.Password = user.Password;
                    context.Entry(oldUser).State = EntityState.Modified;;
                }
                else
                {
                    context.Users.Add(user.ToOrmUser()); 
                }
                context.SaveChanges();
            }
        }
    }
}
