using System;
using BLL.DomainModel.Entities;
using BLL.DomainModel.Enums;

namespace Web.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public byte[] Avatar { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public UserDto(int id, string name, string lastName, Role role)
        {
            Id = id;
            FirstName = name;
            LastName = lastName;
            Role = role;
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Birthday = user.Birthday.HasValue ? user.Birthday.Value.ToString("MM/dd/yyyy") : string.Empty;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Login = user.Login;
            Password = string.Empty;
            Phone = user.Phone;
            Role = user.Role;
            Skype = user.Skype;
        }
    }
}