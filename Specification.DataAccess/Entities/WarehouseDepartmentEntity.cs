using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Отдел отвечающий за СКЛАД
/// Сущность описывает поля которые заполняет отдел
/// </summary>
public class WarehouseDepartmentEntity
{
    public int WarehouseDepId { get; set; }

    /// <summary>
    /// Кол-во на складе без закупки
    /// </summary>
    public string CountOnStorage { get; set; } = string.Empty;

    #region Основаня единица измерения

    public int GenUnitId { get; set; }
    public UnitOfMeasureEntity? GenUom { get; set; }

    #endregion
    /// <summary>
    /// Количество на кладе после закупки
    /// </summary>
    public string CountAfterPurchase { get; set; } = string.Empty;

    #region Дополнительная единица измерения

    public int RemainsUnitId { get; set; }
    public UnitOfMeasureEntity? Uom { get; set; }

    #endregion
    /// <summary>
    /// Остаток на складе после закупки
    /// </summary>
    public string RemainsCountAfterPurchase { get; set; } = string.Empty;

    /// <summary>
    ///  Документ списания
    /// </summary>
    public string WriteOfDoc { get; set; } = string.Empty;

    /// <summary>
    /// Дата списания
    /// </summary>
    public DateTime WriteOfDate { get; set; }

    /// <summary>
    /// Подтверждение установки (Кто установил)
    /// </summary>
    public string AcceptSets { get; set; } = string.Empty;

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
