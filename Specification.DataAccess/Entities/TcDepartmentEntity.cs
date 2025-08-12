using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Отдел технического контроля.
/// Сущность описывает поля которые заполняет отдел
/// </summary>
public class TcDepartmentEntity
{
    public int TcDepId { get; set; }

    /// <summary>
    /// Название/марка по паспорту
    /// </summary>
    public string NameBrandInDoc { get; set; } = string.Empty;

    /// <summary>
    /// Количество
    /// </summary>
    public float Count { get; set; }

    #region Единица измерения

    public int UnitId { get; set; }
    public UnitOfMeasureEntity? Uom { get; set; }

    #endregion


    /// <summary>
    /// Состав компонента
    /// </summary>
    public string CompKit { get; set; } = string.Empty;

    /// <summary>
    /// Состав технической документации(Наличие)
    /// </summary>
    public string CompTechDocAvailable { get; set; } = string.Empty;

    /// <summary>
    /// Состав техницеской документации(Отсутствие)
    /// </summary>
    public string CompTechDocMissing { get; set; } = string.Empty;

    /// <summary>
    /// Дефекты
    /// </summary>
    public string Defects { get; set; } = string.Empty;

    /// <summary>
    /// Заключение
    /// </summary>
    public string Conclusion { get; set; } = string.Empty;

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; set; } = String.Empty;

    #region Ответственный

    public Guid? EmployerResponsibleId { get; set; }
    public EmployerEntity? EmployerData { get; set; }

    #endregion

    /// <summary>
    /// Внещний ключ для связи с таблицей DeviceChapterEntity
    /// </summary>
    public Guid DeviceChapterId { get; set; }
    public DevicesChapterEntity? DeviceChapter { get; set; }
}
