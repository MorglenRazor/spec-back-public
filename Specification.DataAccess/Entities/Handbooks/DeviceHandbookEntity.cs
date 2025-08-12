using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Entities.Handbooks
{
    public class DeviceHandbookEntity
    {
        /// <summary>
        /// Индификатор устройства
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Наименование устройства (прим. Светильник(Аварийный))
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Наименование марки (прим. Lg 14-das)
        /// </summary>
        public string BrandName { get; set; } = string.Empty;

        //public Guid? SubCategoryId { get; set; }
        //public SubCategoryDeviceEntity? SubCategory { get; set; }

        public Guid? CategoryId { get; set; }
        public CategoryDeviceEntity? Category { get; set; }

        /// <summary>
        /// Связь с DevicesChapterEntity
        /// </summary>
        public List<DevicesChapterEntity> DevicesChapter { get; set; } = [];
    }
}
