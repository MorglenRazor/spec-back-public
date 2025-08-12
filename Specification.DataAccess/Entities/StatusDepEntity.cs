  namespace Specification.DataAccess.Entities
{
    public class StatusDepEntity
    {
        public int Id { get; set; }
        public Guid StatusId { get; set; }
        public Guid DepId { get; set; }
    }
}
