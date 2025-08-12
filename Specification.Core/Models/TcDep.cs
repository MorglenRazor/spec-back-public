namespace Specification.Core.Models;

public class TcDep
{
    private TcDep(
        int id,
        string name,
        float count,
        //string sNum,
        string cKit,
        string ctda,
        string ctdm,
        string defects,
        string conc,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chapDeviceId
    )
    {
        TcDepId = id;
        NameBrandInDoc = name;
        Count = count;
       // SerialNum = sNum;
        CompKit = cKit;
        CompTechDocAvailable = ctda;
        CompTechDocMissing = ctdm;
        Defects = defects;
        Conclusion = conc;
        Comment = comment;
        UnitId = unitId;
        EmpRespId = empRespId;
        ChapterDeviceId = chapDeviceId;
    }

    private TcDep(
        int id,
        string name,
        float count,
        //string sNum,
        string cKit,
        string ctda,
        string ctdm,
        string defects,
        string conc,
        string comment,
        string unitName,
        string empShortName,
        Guid chapDeviceId,
        int unitId,
        Guid? empRespId
    )
    {
        TcDepId = id;
        NameBrandInDoc = name;
        Count = count;
        //SerialNum = sNum;
        CompKit = cKit;
        CompTechDocAvailable = ctda;
        CompTechDocMissing = ctdm;
        Defects = defects;
        Conclusion = conc;
        Comment = comment;
        UnitName = unitName;
        EmpShortName = empShortName;
        ChapterDeviceId = chapDeviceId;
        UnitId = unitId;
        EmpRespId = empRespId;
    }

    /// <summary>
    /// Создание модели OTC
    /// </summary>
    /// <param name="id">Инфикатор</param>
    /// <param name="name">Название/марка по паспорту</param>
    /// <param name="count">Количество</param>
    /// <param name="sNum">Заводские/серийные номер</param>
    /// <param name="cKit">Состав компонента</param>
    /// <param name="ctda">Состав технической документации(Наличие)</param>
    /// <param name="ctdm">Состав техницеской документации(Отсутствие)</param>
    /// <param name="defects">Дефекты</param>
    /// <param name="conc">Заключение</param>
    /// <param name="comment">Примечание</param>
    /// <param name="unitId">Индификатор единицы измерения</param>
    /// <param name="chapDeviceId">Индификатор раздела</param>
    /// <returns>Возврат: Словарь(Модель OTС, Модель Ошибок)</returns>
    public static (TcDep otc, string err) Create(
        int id,
        string name,
        float count,
       // string sNum,
        string cKit,
        string ctda,
        string ctdm,
        string defects,
        string conc,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chapDeviceId
    )
    {
        TcDep otc = new TcDep(
            id,
            name,
            count,
          //  sNum,
            cKit,
            ctda,
            ctdm,
            defects,
            conc,
            comment,
            unitId,
            empRespId,
            chapDeviceId
        );
        return (otc, "Без ошибок");
    }

    public static (TcDep otc, string err) Create(
        int id,
        string name,
        float count,
        //string sNum,
        string cKit,
        string ctda,
        string ctdm,
        string defects,
        string conc,
        string comment,
        string unitName,
        string empShortName,
        Guid chapDeviceId,
        int unitId,
        Guid? empRespId
    )
    {
        TcDep otc = new TcDep(
            id,
            name,
            count,
          //  sNum,
            cKit,
            ctda,
            ctdm,
            defects,
            conc,
            comment,
            unitName,
            empShortName,
            chapDeviceId,
            unitId,
            empRespId
        );
        return (otc, "Без ошибок");
    }

    public int TcDepId { get; }

    /// <summary>
    /// Название/марка по паспорту
    /// </summary>
    public string NameBrandInDoc { get; } = string.Empty;

    /// <summary>
    /// Количество
    /// </summary>
    public float Count { get; set; }

    /// <summary>
    /// Заводские/серийные номер
    /// </summary>
    //public string SerialNum { get; } = string.Empty;

    /// <summary>
    /// Состав компонента
    /// </summary>
    public string CompKit { get; } = string.Empty;

    /// <summary>
    /// Состав технической документации(Наличие)
    /// </summary>
    public string CompTechDocAvailable { get; } = string.Empty;

    /// <summary>
    /// Состав техницеской документации(Отсутствие)
    /// </summary>
    public string CompTechDocMissing { get; } = string.Empty;

    /// <summary>
    /// Дефекты
    /// </summary>
    public string Defects { get; } = string.Empty;

    /// <summary>
    /// Заключение
    /// </summary>
    public string Conclusion { get; } = string.Empty;

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = String.Empty;

    public int UnitId { get; }

    public string UnitName { get; }

    public Guid? EmpRespId { get; }

    public string EmpShortName { get; }

    public Guid ChapterDeviceId { get; }
}
