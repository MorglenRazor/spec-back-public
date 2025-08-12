namespace Specification.Core.Models;

public class AccountingDep
{
    private AccountingDep(
        int id,
        string name,
        float cf,
        decimal prcOnOneTax,
        decimal amTax,
        string arc,
        DateTime dtDev,
        decimal price,
        string ad,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chpDeviceId
    )
    {
        AccountingDepId = id;
        NameBrandForUpd = name;
        CountFact = cf;
        PriceOnOneTax = prcOnOneTax;
        AmountTax = amTax;
        Article = arc;
        DateDev = dtDev;
        Price = price;
        AcompDoc = ad;
        Comment = comment;
        UnitId = unitId;
        EmpRespId = empRespId;
        ChapterDeviceId = chpDeviceId;
    }

    private AccountingDep(
        int id,
        string name,
        float cf,
        decimal prcOnOneTax,
        decimal amTax,
        string arc,
        DateTime dtDev,
        decimal price,
        string ad,
        string comment,
        string unitName,
        string empShortName,
        Guid chpDeviceId,
        int unitId,
        Guid? empRespId
    )
    {
        AccountingDepId = id;
        NameBrandForUpd = name;
        CountFact = cf;
        PriceOnOneTax = prcOnOneTax;
        AmountTax = amTax;
        Article = arc;
        DateDev = dtDev;
        Price = price;
        AcompDoc = ad;
        Comment = comment;
        UnitName = unitName;
        EmpShortName = empShortName;
        ChapterDeviceId = chpDeviceId;
        UnitId = unitId;
        EmpRespId = empRespId;
    }

    /// <summary>
    /// Создание модели AccountPart
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name">Наименование и марка по УПД</param>
    /// <param name="cf">Количество по факту</param>
    /// <param name="prcOnOneTax">Цена за единицу с НДС</param>
    /// <param name="amTax">Сумма с НДС</param>
    /// <param name="arc">Артикул</param>
    /// <param name="dtDev">Дата заполеннеия()</param>
    /// <param name="price">Цена</param>
    /// <param name="ad">Сопроводительный документ</param>
    /// <param name="comment">Примечание</param>
    /// <param name="unitId"> единица измерения</param>
    /// <param name="respHdId"> индификатор ответственного</param>
    /// <param name="chpDeviceId">Индификатор устройства раздела</param>
    /// <returns>Возврат: Словарь(Модель AccountPart, Модель Ошибок)</returns>
    public static (AccountingDep accountPart, string err) Create(
        int id,
        string name,
        float cf,
        decimal prcOnOneTax,
        decimal amTax,
        string arc,
        DateTime dtDev,
        decimal price,
        string ad,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chpDeviceId
    )
    {
        AccountingDep accountingDep = new AccountingDep(
            id,
            name,
            cf,
            prcOnOneTax,
            amTax,
            arc,
            dtDev,
            price,
            ad,
            comment,
            unitId,
            empRespId,
            chpDeviceId
        );
        return (accountingDep, "Без ошибок");
    }

    public static (AccountingDep accountPart, string err) Create(
        int id,
        string name,
        float cf,
        decimal prcOnOneTax,
        decimal amTax,
        string arc,
        DateTime dtDev,
        decimal price,
        string ad,
        string comment,
        string unitName,
        string respShortName,
        Guid chpDeviceId,
        int unitId,
        Guid? empRespId
    )
    {
        AccountingDep accountingDep = new AccountingDep(
            id,
            name,
            cf,
            prcOnOneTax,
            amTax,
            arc,
            dtDev,
            price,
            ad,
            comment,
            unitName,
            respShortName,
            chpDeviceId,
            unitId,
            empRespId
        );
        return (accountingDep, "Без ошибок");
    }

    public int AccountingDepId { get; }

    /// <summary>
    /// Наименование и марка по УПД
    /// </summary>
    public string NameBrandForUpd { get; } = string.Empty;

    /// <summary>
    /// Количество по факту
    /// </summary>
    public float CountFact { get; }

    /// <summary>
    /// Цена за единицу с НДС
    /// </summary>
    public decimal PriceOnOneTax { get; }

    /// <summary>
    /// Сумма с НДС
    /// </summary>
    public decimal AmountTax { get; }

    /// <summary>
    /// Артикул
    /// </summary>
    public string Article { get; } = string.Empty;

    /// <summary>
    /// Сопроводительный документ
    /// </summary>
    public string AcompDoc { get; } = string.Empty;

    /// <summary>
    /// Дата заполеннеия()
    /// </summary>
    public DateTime DateDev { get; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = String.Empty;

    /// <summary>
    /// единица измерения
    /// </summary>
    public int UnitId { get; }

    public string UnitName { get; }

    /// <summary>
    /// Индификатор  ответсвенного из ResponsibleHandbook
    /// </summary>
    public Guid? EmpRespId { get; }

    public string EmpShortName { get; } = string.Empty;

    /// <summary>
    ///
    /// </summary>
    public Guid ChapterDeviceId { get; }
}
