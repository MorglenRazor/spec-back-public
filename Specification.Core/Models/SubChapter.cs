using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models
{
    public class SubChapter
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sChId">Индификатор SubChapter</param>
        /// <param name="sCdId">Индификатор SubCategoryDevice</param>
        /// <param name="chId">Индификатор Chapter</param>
        private SubChapter(Guid sChId, Guid CdId, Guid chId)
        {
            SubChapId = sChId;
            CategoryDeviceId = CdId;
            ChapterId = chId;
        }

        /// <summary>
        /// Метод для профиля
        /// </summary>
        /// <param name="subChapId"></param>
        /// <param name="catId"></param>
        /// <param name="chId"></param>
        /// <param name="specId"></param>
        /// <param name="catName"></param>
        /// <param name="countDevice"></param>
        /// <param name="specName"></param>
        /// <param name="devices"></param>
        private SubChapter(Guid subChapId, Guid catId, Guid chId, Guid specId, string catChapName, string catName, int countDevice, string specName, List<DevicesChapter> devices)
        {
            SubChapId = subChapId;
            CategoryDeviceId = catId;
            ChapterId = chId;
            SpecId = specId;
            CategoryName = catName;
            CountDevice = countDevice;
            SpecName = specName;
            CategoryChapName = catChapName;
            Devices = devices;
        }

        /// <summary>
        /// Метод создания SubChapter
        /// </summary>
        /// <returns>Модель SubChapter</returns>
        public static (SubChapter sch, string err) CreateProfile(Guid subChapId, Guid catId, Guid chId, Guid specId, string catChapName, string catName, int countDevice, string specName, List<DevicesChapter> devices)
        {
            SubChapter subChapter = new SubChapter(subChapId, catId, chId, specId, catChapName, catName, countDevice, specName, devices);
            return (subChapter, "Без ошибок");
        }

        /// <summary>
        /// Конструктор с названием под категории
        /// </summary>
        /// <param name="sChId">Индификатор SubChapter</param>
        /// <param name="sCdId">Индификатор SubCategoryDevice</param>
        /// <param name="chId">Индификатор Chapter</param>
        /// <param name="subCategoryName">Наменование под-категории</param>
        private SubChapter(Guid sChId, Guid CdId, Guid chId, string categoryName)
        {
            SubChapId = sChId;
            CategoryDeviceId = CdId;
            ChapterId = chId;
            CategoryName = categoryName;
        }

        /// <summary>
        /// Метод создания SubChapter
        /// </summary>
        /// <param name="sChId">Индификатор SubChapter</param>
        /// <param name="sCdId">Индификатор SubCategoryDevice</param>
        /// <param name="chId">Индификатор Chapter</param>
        /// <returns>Модель SubChapter</returns>
        public static (SubChapter sch, string err) Create(Guid sChId, Guid CdId, Guid chId)
        {
            SubChapter subChapter = new SubChapter(sChId, CdId, chId);
            return (subChapter, "Без ошибок");
        }

        public static (SubChapter sch, string err) Create(
            Guid sChId,
            Guid CdId,
            Guid chId,
            string categoryName
        )
        {
            SubChapter subChapter = new SubChapter(sChId, CdId, chId, categoryName);
            return (subChapter, "Без ошибок");
        }

        public Guid SubChapId { get; }
        #region дополнительная категория
        public Guid CategoryDeviceId { get; }
        #endregion
        public string CategoryName { get; } = string.Empty;
        public string CategoryChapName { get; } = string.Empty;
        public Guid ChapterId { get; }
        public int CountDevice { get; set; }
        public Guid SpecId { get; set; }
        public string SpecName { get; set; }
        public List<DevicesChapter> Devices { get; set; } = [];

    }
}
