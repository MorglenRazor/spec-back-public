using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Entities.Handbooks
{
    public class CategoryDeviceEntity
    {
        public Guid CategoryDeviceId { get; set; }

        /// <summary>
        /// Название категории (прим. Электрооборудование)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public Guid CategoryChapterId { get; set; }

        public CategoryChapterHandbookEntity? CategoryChapter { get; set; }

        /// <summary>
        /// Связь с ChapterEntity
        /// </summary>
        public List<SubChapterEntity> SubChapters { get; set; } = [];

        public List<DeviceHandbookEntity> Devices { get; set; } = [];
    }
}
