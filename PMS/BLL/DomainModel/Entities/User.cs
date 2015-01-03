﻿using System;
using BLL.DomainModel.Enums;

namespace BLL.DomainModel.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? [] Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public DateTime? CreationDate { get; set; }

    }
}
