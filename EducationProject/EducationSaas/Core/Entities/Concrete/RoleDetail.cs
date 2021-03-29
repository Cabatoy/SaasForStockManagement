namespace Core.Entities.Concrete
{
    public class RoleDetail : IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Description { get; set; }
    }
}
