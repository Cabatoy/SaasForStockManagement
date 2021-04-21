﻿namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PassWordSalt { get; set; }
        public byte[] PassWordHash { get; set; }
        public int RoleId { get; set; }
        public bool Deleted { get; set; }
    }
}
