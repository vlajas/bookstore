﻿namespace bookstore.Shared.Entities
{
    public class UserRoleMapping : BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}