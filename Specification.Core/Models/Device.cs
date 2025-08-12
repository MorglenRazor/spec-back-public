using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models
{
    public class Device
    {
        private Device(Guid id, string name, string brandName, Guid? categoryId)
        {
            DeviceId = id;
            Name = name;
            BrandName = brandName;
            CategoryDeviceId = categoryId;
        }

        /// <summary>
        /// Метод для создания Модели Device
        /// </summary>
        /// <param name="id">Индификатор устройства</param>
        /// <param name="name">Наименование устройства (прим. Светильник(Аварийный))</param>
        /// <param name="brandName">Наименование марки (прим. Lg 14-das)</param>
        /// <returns>Возврат: Словарь(Модель Device, Модель Ошибок)</returns>
        public static (Device device, string err) Create(
            Guid id,
            string name,
            string brandName,
            Guid? categoryId
        )
        {
            Device device = new Device(id, name, brandName, categoryId);
            return (device, "Без ошибок");
        }

        /// <summary>
        /// Индификатор устройства
        /// </summary>
        public Guid DeviceId { get; }

        /// <summary>
        /// Наименование устройства (прим. Светильник(Аварийный))
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        /// Наименование марки (прим. Lg 14-das)
        /// </summary>
        public string BrandName { get; } = string.Empty;

        public Guid? CategoryDeviceId { get; }
    }
}
