using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Отдел технического материального снабжения.
/// Сущность описывает поля которые заполняет отдел
/// </summary>
public class TmsDepartmentEntity
{
    public int TmsDepId { get; set; }

    /// <summary>
    /// Название/марка для покупки(если не найдена точная )
    /// </summary>
    public string NameBrandForPurchase { get; set; } = string.Empty;

    /// <summary>
    /// Кол-во закупаемых устройств
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Дата поставки по договору
    /// </summary>
    //public DateTime DodContract { get; set; }

    /// <summary>
    /// Планируемая дата поставки
    /// </summary>
    public DateTime DodPlan { get; set; }

    /// <summary>
    /// Фактическая дата поставки
    /// </summary>
    public DateTime DodFact { get; set; }

    /// <summary>
    /// Цена без НДС
    /// </summary>
    public decimal PriceNoTax { get; set; }

    /// <summary>
    /// Цена с НДС
    /// </summary>
    public decimal PriceWithTax { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Номер счета
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// Дата счета
    /// </summary>
    public DateTime DateAccount { get; set; }

    /// <summary>
    /// Первая оплата
    /// </summary>
    //public decimal FirstPay { get; set; }

    /// <summary>
    /// Дата первой оплаты
    /// </summary>
    //public DateTime DateFirstPay { get; set; }

    /// <summary>
    /// Вторая оплата
    /// </summary>
    //public decimal SecondPay { get; set; }

    /// <summary>
    /// Дата второй оплаты
    /// </summary>
   // public DateTime DateSecondPay { get; set; }

    /// <summary>
    /// Третья оплата
    /// </summary>
    //public decimal ThirdPay { get; set; }

    /// <summary>
    /// Дата треьей оплаты
    /// </summary>
   // public DateTime DateThirdPay { get; set; }

    /// <summary>
    /// Остаток по оплате
    /// </summary>
   // public decimal PaymentBalance { get; set; }

    /// <summary>
    /// Стоимость возврата
    /// </summary>
    //public decimal CostOfRefand { get; set; }

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

    #region Подрядчик

    public int ContractorId { get; set; }
    public ContractorEntity? Contractor { get; set; }

    #endregion
}
