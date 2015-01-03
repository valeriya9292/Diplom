using System;
using System.Linq;
using System.Web.Security;
using BLL.DomainModel.Enums;
using BLL.Services;
using DI.Infrastructure;

namespace Web.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        private readonly UserService userService;

        public CustomRoleProvider()
        {
           userService = (UserService)new NinjectDependencyResolver().GetService(typeof(UserService));
        }
        public bool IsUserInRole(string login, Role role)
        {
            var user =  (from u in userService.FindAllUsers()
                             where u.Login == login
                            select u).FirstOrDefault();
            if (user == null) return false;

            return user.Role == role;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string login)
        {
            var roles = new string[] { };
            var user = userService.FindAllUsers().FirstOrDefault(u => u.Login == login);
            if (user == null) return roles;
            roles = new []{user.Role.ToString()};
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}