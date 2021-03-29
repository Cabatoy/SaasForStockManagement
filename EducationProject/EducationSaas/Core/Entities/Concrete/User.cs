namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string FullName { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }

        public int RoleId { get; set; }
    }
}
