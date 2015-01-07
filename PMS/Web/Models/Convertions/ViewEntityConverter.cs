using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;
using BLL.DomainModel.Entities;
using BLL.DomainModel.Enums;

namespace Web.Models.Convertions
{
    public static class OrmEntityConverter
    {
        public static User ToEntityUser(this CreateUserModel user)
        {
            MemoryStream target = null;
            if (user.Avatar != null)
            {
                target = new MemoryStream();
                user.Avatar.InputStream.CopyTo(target);
            }

            return new User()
            {
                //Id = user.Id,
                Avatar = target != null ? target.ToArray() : null,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = Crypto.HashPassword(user.Password),
                Phone = user.Phone,
                Role = user.Role,
                Skype = user.Skype,
                CreationDate = DateTime.Now
            };
        }
        public static CreateUserModel ToViewUser(this User user)
        {
            return new CreateUserModel()
            {
                Id = user.Id,
                //Avatar = user.Avatar,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Phone = user.Phone,
                Role = user.Role,
                Skype = user.Skype,
            };
        }
        public static User ToEntityUserFromEdit(this EditUserModel user)
        {
            MemoryStream target = null;
            if (user.Avatar != null)
            {
                target = new MemoryStream();
                user.Avatar.InputStream.CopyTo(target);
            }

            return new User()
            {
                Id = user.Id,
                Avatar = target != null ? target.ToArray() : null,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = string.IsNullOrEmpty(user.Password) ? string.Empty : Crypto.HashPassword(user.Password),
                Phone = user.Phone,
                Role = user.Role,
                Skype = user.Skype,
                Login = user.Login
            };
        }
        public static EditUserModel ToViewEditUser(this User user)
        {
            return new EditUserModel()
            {
                Id = user.Id,
                //Avatar = user.Avatar,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Phone = user.Phone,
                Role = user.Role,
                Skype = user.Skype,
            };
        }

    }
}
