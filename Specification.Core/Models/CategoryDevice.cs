using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models
{
    public class CategoryDevice
    {
        private CategoryDevice(Guid id, string name)
        {
            CategoryDeviceId = id;
            Name = name;
        }

        private CategoryDevice(Guid id, string name, Guid categoryChapterId)
        {
            CategoryDeviceId = id;
            Name = name;
            CategoryChapterId = categoryChapterId;
        }

        /// <summary>
        /// Метод для создания Модели CategoryDevice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">Название категории (прим. Электрооборудование)</param>
        /// <param name="devices">Список устройств с этой категории</param>
        /// <returns>Возврат: Словарь(Модель CategoryDevice, Модель Ошибок)</returns>
        public static (CategoryDevice categoryDevice, string err) Create(Guid id, string name)
        {
            CategoryDevice categoryDevice = new CategoryDevice(id, name);
            return (categoryDevice, "Без ошибок");
        }

        public static (CategoryDevice categoryDevice, string err) Create(Guid id, string name, Guid categoryChapterId)
        {
            CategoryDevice categoryDevice = new CategoryDevice(id, name, categoryChapterId);
            return (categoryDevice, "Без ошибок");
        }

        public Guid CategoryDeviceId { get; }

        /// <summary>
        /// Название категории (прим. Электрооборудование)
        /// </summary>
        public string Name { get; } = string.Empty;
        public Guid CategoryChapterId { get; set; }
    }
}
