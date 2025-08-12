namespace Specification.Core.Models;

public class WarehouseDep
{
    private WarehouseDep(
        int id,
        string cos,
        string cap,
        string rCap,
        //string sNum,
        //string wod,
        //DateTime wodt,
        //string acs,
        string comment,
        int getUnitId,
        int dopUnitId,
        Guid chpDeviceId,
        Guid? empRespId
    )
    {
        WarehouseDepId = id;
        CountOnStorage = cos;
        CountAfterPurchase = cap;
        RemainsCountAfterPurchase = rCap;
        //SerialNumber = sNum;
        //WriteOfDoc = wod;
        //WriteOfDate = wodt;
        //AcceptSets = acs;
        Comment = comment;
        GenUnitId = getUnitId;
        RemainsUnitId = dopUnitId;
        ChapterDeviceId = chpDeviceId;
        EmpRespId = empRespId;
    }

    private WarehouseDep(
        int id,
        string cos,
        string cap,
        string rCap,
        //string sNum,
        //string wod,
        //DateTime wodt,
        //string acs,
        string comment,
        string getUnitName,
        string dopUnitName,
        Guid chpDeviceId,
        string empShortName,
        int genUnitId,
        int remUnitId,
        Guid? empRespId
    )
    {
        WarehouseDepId = id;
        CountOnStorage = cos;
        CountAfterPurchase = cap;
        RemainsCountAfterPurchase = rCap;
        //SerialNumber = sNum;
        //WriteOfDoc = wod;
        //WriteOfDate = wodt;
        //AcceptSets = acs;
        Comment = comment;
        GenUnitName = getUnitName;
        RemainsUnitName = dopUnitName;
        ChapterDeviceId = chpDeviceId;
        EmpShortName = empShortName;
        GenUnitId = genUnitId;
        RemainsUnitId = remUnitId;
        EmpRespId = empRespId;
    }

    /// <summary>
    /// Создание модели StoragePart
    /// </summary>
    /// <param name="id">Индификатор</param>
    /// <param name="cos">Кол-во на складе без закупки</param>
    /// <param name="cap">Количество на кладе после закупки</param>
    /// <param name="rCap">Остаток на складе после закупки</param>
    /// <param name="sNum">Серийный номер</param>
    /// <param name="wod">Документ списания</param>
    /// <param name="wodt">Дата списания</param>
    /// <param name="acs">Подтверждение установки (Кто установил)</param>
    /// <param name="comment">Примечание</param>
    /// <param name="getUnitId">Индификатор осн. ед. измерения</param>
    /// <param name="dopUnitId">Индификатор доп ед. измерения</param>
    /// <param name="chpDeviceId"> Индификатор раздела </param>
    /// <returns>Возврат: Словарь(Модель Storage, Модель Ошибок)</returns>
    public static (WarehouseDep storagePart, string Err) Create(
        int id,
        string cos,
        string cap,
        string rCap,
        //string sNum,
        //string wod,
        //DateTime wodt,
        //string acs,
        string comment,
        int getUnitId,
        int dopUnitId,
        Guid chpDeviceId,
        Guid? empRespId
    )
    {
        WarehouseDep warehouseDep = new WarehouseDep(
            id,
            cos,
            cap,
            rCap,
            //sNum,
            //wod,
            //wodt,
            //acs,
            comment,
            getUnitId,
            dopUnitId,
            chpDeviceId,
            empRespId
        );
        return (warehouseDep, "Без ошибок");
    }

    public static (WarehouseDep storagePart, string Err) Create(
        int id,
        string cos,
        string cap,
        string rCap,
        //string sNum,
        //string wod,
        //DateTime wodt,
        //string acs,
        string comment,
        string getUnitName,
        string dopUnitName,
        Guid chpDeviceId,
        string empShortName,
        int genUnitId,
        int remUnitId,
        Guid? empRespId
    )
    {
        WarehouseDep warehouseDep = new WarehouseDep(
            id,
            cos,
            cap,
            rCap,
            //sNum,
            //wod,
            //wodt,
            //acs,
            comment,
            getUnitName,
            dopUnitName,
            chpDeviceId,
            empShortName,
            genUnitId,
            remUnitId,
            empRespId
        );
        return (warehouseDep, "Без ошибок");
    }

    // public static (WarehouseDep storagePart, string Err) Create(int id, bool eos, string cos,
    //     string cap, string rCap, string sNum, string wod, DateTime wodt, string acs, string comment,
    //     int getUnitId, int dopUnitId, Guid chpDeviceId)
    // {
    //     WarehouseDep warehouseDep = new WarehouseDep(id, eos, cos, cap, rCap, sNum, wod, wodt, acs, comment,
    //         getUnitId, dopUnitId, chpDeviceId);
    //     return (warehouseDep, "Без ошибок");
    // }

    public int WarehouseDepId { get; }

    /// <summary>
    /// Кол-во на складе без закупки
    /// </summary>
    public string CountOnStorage { get; } = string.Empty;

    /// <summary>
    /// Количество на кладе после закупки
    /// </summary>
    public string CountAfterPurchase { get; } = string.Empty;

    /// <summary>
    /// Остаток на складе после закупки
    /// </summary>
    public string RemainsCountAfterPurchase { get; } = string.Empty;



    /// <summary>
    ///  Документ списания
    /// </summary>
    //public string WriteOfDoc { get; } = string.Empty;

    /// <summary>
    /// Дата списания
    /// </summary>
    //public DateTime WriteOfDate { get; }

    /// <summary>
    /// Подтверждение установки (Кто установил)
    /// </summary>
    //public string AcceptSets { get; } = string.Empty;

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = String.Empty;

    /// <summary>
    /// Основаня единица измерения
    /// </summary>
    public int GenUnitId { get; }
    public string GenUnitName { get; }

    /// <summary>
    /// Дополнительная единица измерения
    /// </summary>
    public int RemainsUnitId { get; }
    public string RemainsUnitName { get; }

    /// <summary>
    /// Внещний ключ для связи с таблицей ChapterEntity
    /// </summary>
    public Guid ChapterDeviceId { get; }

    public Guid? EmpRespId { get; }

    public string EmpShortName { get; }
}
