using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities
{
    /// <summary>
    /// Сущность под-раздела
    /// </summary>
    public class SubChapterEntity
    {
        public Guid SubChapId { get; set; }

        #region основная категория
        public Guid CategoryDeviceId { get; set; }

        public CategoryDeviceEntity? CategoryDevice { get; set; }
        #endregion

        public Guid ChapterId { get; set; }
        public ChapterEntity? ChapterEntity { get; set; }
        public List<DevicesChapterEntity> Devices { get; set; } = [];
        //public List<GroupDeviceEntity>? Group { get; set; }
    }
}
