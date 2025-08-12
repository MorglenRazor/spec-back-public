using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Бухгалтерский отдел.
/// Сущность описывает поля которые заполняет отдел
/// </summary>
public class AccountingDepartmentEntity
{
    public int AccountingDepId { get; set; }

    /// <summary>
    /// Наименование и марка по УПД
    /// </summary>
    public string NameBrandForUpd { get; set; } = string.Empty;

    #region  единица измерения

    public int UnitId { get; set; }
    public UnitOfMeasureEntity? Uom { get; set; }

    #endregion

    /// <summary>
    /// Количество по факту
    /// </summary>
    public float CountFact { get; set; }

    /// <summary>
    /// Цена за единицу с НДС
    /// </summary>
    public decimal PriceOnOneTax { get; set; }

    /// <summary>
    /// Сумма с НДС
    /// </summary>
    public decimal AmountTax { get; set; }

    /// <summary>
    /// Артикул
    /// </summary>
    public string Article { get; set; } = string.Empty;

    /// <summary>
    /// Сопроводительный документ
    /// </summary>
    public string AcompDoc { get; set; } = string.Empty;

    /// <summary>
    /// Дата заполеннеия()
    /// </summary>
    public DateTime DateDev { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

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
