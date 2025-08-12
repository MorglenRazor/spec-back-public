using System.Runtime.Intrinsics.Arm;

namespace Specification.Core.Models;

public class TmsDep
{
    private TmsDep(
        int id,
        string name,
        int count,
      //  DateTime dodc,
        DateTime dodp,
        DateTime dodf,
        decimal pnt,
        decimal pwt,
        decimal amt,
        string an,
        DateTime dta,
        //decimal fp,
        //DateTime dtfp,
        //decimal sp,
        //DateTime dtsp,
        //decimal tp,
        //DateTime dttp,
        //decimal pb,
        //decimal cor,
        string comment,
        Guid chpDeviceId,
        int contId,
        Guid? empRespId
    )
    {
        TmsDepId = id;
        NameBrandForPurchase = name;
        Count = count;
      //  DodContract = dodc;
        DodPlan = dodp;
        DodFact = dodf;
        PriceNoTax = pnt;
        PriceWithTax = pwt;
        Amount = amt;
        AccountNumber = an;
        DateAccount = dta;
        //FirstPay = fp;
        //DateFirstPay = dtfp;
        //SecondPay = sp;
        //DateSecondPay = dtsp;
        //ThirdPay = tp;
        //DateThirdPay = dttp;
        //PaymentBalance = pb;
        //CostOfRefand = cor;
        Comment = comment;
        ChapDeviceId = chpDeviceId;
        ContId = contId;
        EmpRespId = empRespId;
    }

    private TmsDep(
        int id,
        string name,
        int count,
     //   DateTime dodc,
        DateTime dodp,
        DateTime dodf,
        decimal pnt,
        decimal pwt,
        decimal amt,
        string an,
        DateTime dta,
        //decimal fp,
        //DateTime dtfp,
        //decimal sp,
        //DateTime dtsp,
        //decimal tp,
        //DateTime dttp,
        //decimal pb,
        //decimal cor,
        string comment,
        Guid chpDeviceId,
        string contName,
        string contInn,
        string empShortName,
        int contId,
        Guid? empRespId
    )
    {
        TmsDepId = id;
        NameBrandForPurchase = name;
        Count = count;
       // DodContract = dodc;
        DodPlan = dodp;
        DodFact = dodf;
        PriceNoTax = pnt;
        PriceWithTax = pwt;
        Amount = amt;
        AccountNumber = an;
        DateAccount = dta;
        //FirstPay = fp;
        //DateFirstPay = dtfp;
        //SecondPay = sp;
        //DateSecondPay = dtsp;
        //ThirdPay = tp;
        //DateThirdPay = dttp;
        //PaymentBalance = pb;
        //CostOfRefand = cor;
        Comment = comment;
        ChapDeviceId = chpDeviceId;
        ContName = contName;
        ContInn = contInn;
        EmpShortName = empShortName;
        ContId = contId;
        EmpRespId = empRespId;
    }

    /// <summary>
    /// Метод для создания Модели TmsDep
    /// </summary>
    /// <param name="id">Индификатор</param>
    /// <param name="name">Название/марка для покупки</param>
    /// <param name="dodc">Дата поставки по договору</param>
    /// <param name="dodp">Планируемая дата поставки</param>
    /// <param name="dodf">Фактическая дата поставки</param>
    /// <param name="pnt">Цена без НДС</param>
    /// <param name="pwt">Цена с НДС</param>
    /// <param name="amt">Сумма</param>
    /// <param name="an">Номер счета</param>
    /// <param name="dta">Дата счета</param>
    /// <param name="fp">Первая оплата</param>
    /// <param name="dtfp">Дата первой оплаты</param>
    /// <param name="sp">Вторая оплата</param>
    /// <param name="dtsp">Дата второй оплаты</param>
    /// <param name="tp">Третья оплата</param>
    /// <param name="dttp">Дата треьей оплаты</param>
    /// <param name="pb">Остаток по оплате</param>
    /// <param name="cor">Стоимость возврата</param>
    /// <param name="comment">Примечание</param>
    /// <param name="chpDeviceId">Индификатор Раздела</param>
    /// <param name="contId">Индификатор подрядчика</param>
    /// <returns>Возврат: Словарь(Модель OTMS, Модель Ошибок)</returns>
    public static (TmsDep otms, string err) Create(
        int id,
        string name,
        int count,
      //  DateTime dodc,
        DateTime dodp,
        DateTime dodf,
        decimal pnt,
        decimal pwt,
        decimal amt,
        string an,
        DateTime dta,
        //decimal fp,
        //DateTime dtfp,
        //decimal sp,
        //DateTime dtsp,
        //decimal tp,
        //DateTime dttp,
        //decimal pb,
        //decimal cor,
        string comment,
        Guid chpDeviceId,
        int contId,
        Guid? empRespId
    )
    {
        TmsDep otms = new TmsDep(
            id,
            name,
            count,
        //    dodc,
            dodp,
            dodf,
            pnt,
            pwt,
            amt,
            an,
            dta,
            //fp,
            //dtfp,
            //sp,
            //dtsp,
            //tp,
            //dttp,
            //pb,
            //cor,
            comment,
            chpDeviceId,
            contId,
            empRespId
        );
        return (otms, "Нет ошибок");
    }

    public static (TmsDep otms, string err) Create(
        int id,
        string name,
        int count,
      //  DateTime dodc,
        DateTime dodp,
        DateTime dodf,
        decimal pnt,
        decimal pwt,
        decimal amt,
        string an,
        DateTime dta,
        //decimal fp,
        //DateTime dtfp,
        //decimal sp,
        //DateTime dtsp,
        //decimal tp,
        //DateTime dttp,
        //decimal pb,
        //decimal cor,
        string comment,
        Guid chpDeviceId,
        string contName,
        string contInn,
        string empShortName,
        int contId,
        Guid? empRespId
    )
    {
        TmsDep otms = new TmsDep(
            id,
            name,
            count,
      //      dodc,
            dodp,
            dodf,
            pnt,
            pwt,
            amt,
            an,
            dta,
          //  fp,
           // dtfp,
            //sp,
            //dtsp,
            //tp,
            //dttp,
            //pb,
            //cor,
            comment,
            chpDeviceId,
            contName,
            contInn,
            empShortName,
            contId,
            empRespId
        );
        return (otms, "Нет ошибок");
    }

    // public static (TmsDep otms, string err) Create(int id, bool isRd, string name, DateTime dodc, DateTime dodp,
    //     DateTime dodf, decimal pnt, decimal pwt, decimal amt, string an , DateTime dta, decimal fp,
    //     DateTime dtfp, decimal sp, DateTime dtsp, decimal tp, DateTime dttp, decimal pb,
    //     decimal cor, string comment, Guid chpDeviceId, int contId)
    // {
    //     TmsDep otms = new TmsDep(id, isRd, name, dodc, dodp, dodf, pnt, pwt, amt,
    //         an, dta, fp, dtfp, sp, dtsp, tp, dttp, pb, cor, comment,chpDeviceId, contId);
    //     return (otms, "Нет ошибок");
    // }



    public int TmsDepId { get; }

    /// <summary>
    /// Название/марка для покупки(если не найдена точная )
    /// </summary>
    public string NameBrandForPurchase { get; } = string.Empty;

    /// <summary>
    /// Кол-во закупаемых устройств
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Дата поставки по договору
    /// </summary>
   // public DateTime DodContract { get; }

    /// <summary>
    /// Планируемая дата поставки
    /// </summary>
    public DateTime DodPlan { get; }

    /// <summary>
    /// Фактическая дата поставки
    /// </summary>
    public DateTime DodFact { get; }

    /// <summary>
    /// Цена без НДС
    /// </summary>
    public decimal PriceNoTax { get; }

    /// <summary>
    /// Цена с НДС
    /// </summary>
    public decimal PriceWithTax { get; }

    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Номер счета
    /// </summary>
    public string AccountNumber { get; } = string.Empty;

    /// <summary>
    /// Дата счета
    /// </summary>
    public DateTime DateAccount { get; }

    /// <summary>
    /// Первая оплата
    /// </summary>
    public decimal FirstPay { get; }

    /// <summary>
    /// Дата первой оплаты
    /// </summary>
    public DateTime DateFirstPay { get; }

    /// <summary>
    /// Вторая оплата
    /// </summary>
    public decimal SecondPay { get; }

    /// <summary>
    /// Дата второй оплаты
    /// </summary>
    public DateTime DateSecondPay { get; }

    /// <summary>
    /// Третья оплата
    /// </summary>
    public decimal ThirdPay { get; }

    /// <summary>
    /// Дата треьей оплаты
    /// </summary>
    public DateTime DateThirdPay { get; }

    /// <summary>
    /// Остаток по оплате
    /// </summary>
    public decimal PaymentBalance { get; }

    /// <summary>
    /// Стоимость возврата
    /// </summary>
    public decimal CostOfRefand { get; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = String.Empty;

    /// <summary>
    /// Индификатор устройства раздела
    /// </summary>
    public Guid ChapDeviceId { get; }

    /// <summary>
    /// Индификатор подрядчика
    /// </summary>
    public int ContId { get; }

    public string ContName { get; } = string.Empty;

    public string ContInn { get; } = string.Empty;

    public Guid? EmpRespId { get; }

    public string EmpShortName { get; }
}
