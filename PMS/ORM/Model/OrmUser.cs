using System;
using ORM.Model.Enums;

namespace ORM.Model
{
    public class OrmUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]  Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }   

        public string Login { get; set; }
        public string Password { get; set; }
        public OrmRole Role { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
