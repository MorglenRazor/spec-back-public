using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Сущность хранящая устройства привязанные к разделу
/// </summary>
public class DevicesChapterEntity
{
    /// <summary>
    /// Индификатора устройства
    /// </summary>
    public Guid DeviceChapterId { get; set; }

   

    /// <summary>
    /// Индификатор под-раздела
    /// </summary>
    public Guid SubChapterId { get; set; }

    public SubChapterEntity? SubChapter { get; set; }

    public Guid StatusId { get; set; }
    public StatusDeviceHandbookEntity? Status { get; set; }

    public Guid DeviceId { get; set; }
    public DeviceHandbookEntity? Device { get; set; }

    /// <summary>
    /// Заводские/Серийные номера
    /// </summary>
    public string? SerialNumber { get; set; } = string.Empty;

    /// <summary>
    /// Кол-во требуемых устройств
    /// </summary>
    ///
    public float CountDevice { get; set; }

    /// <summary>
    /// Дата Заполеннеия
    /// </summary>
    public DateTime DateToFilling { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Дата Изменения
    /// </summary>
    public DateTime DateToEditing { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Требуемая дата поставки
    /// </summary>
    public DateTime RequiredProdDate { get; set; }

    /// <summary>
    /// Индификатор комплекта
    /// </summary>
    public Guid? CompId { get; set; } // хранит deviceChapterId главного устрйоста

    /// <summary>
    /// Наименование комплекта
    /// </summary>
    public string CompName { get; set; } = string.Empty;

    //public bool Visible { get; set; }

    /// <summary>
    /// Список
    /// </summary>
    public List<ConstructionDepartmentEntity> ConstructionDep { get; set; } = [];

    /// <summary>
    ///
    /// </summary>
    public List<TmsDepartmentEntity> TechMaterialSuppDep { get; set; } = [];

    /// <summary>
    ///
    /// </summary>
    public List<TcDepartmentEntity> TechControlDep { get; set; } = [];

    /// <summary>
    ///
    /// </summary>
    public List<WarehouseDepartmentEntity> WarehouseDep { get; set; } = [];

    /// <summary>
    ///
    /// </summary>
    public List<AccountingDepartmentEntity> AccountingDep { get; set; } = [];


}
