﻿using System.Collections.Generic;

namespace bookstore.Core.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Roles { get; set; }
    }
}
