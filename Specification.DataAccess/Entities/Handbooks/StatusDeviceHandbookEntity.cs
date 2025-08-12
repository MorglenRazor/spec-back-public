namespace Specification.DataAccess.Entities.Handbooks
{
    public class StatusDeviceHandbookEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid DepId { get; set; }
        public DepartmentEntity? DepartmentCurrWork { get; set; }

        public bool IsVisible { get; set; }

        public short Rank { get; set; } = 0;

        /// <summary>
        /// Связь с DevicesChapterEntity
        /// </summary>
        public List<DevicesChapterEntity> DevicesChapter { get; set; } = [];
    }
}
