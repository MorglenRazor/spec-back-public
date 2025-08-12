namespace Specification.Core.Models;

public class DevicesChapter
{

    private DevicesChapter(Guid deviceChapId)
    {
       DeviceChapterId = deviceChapId;
    }

    public static DevicesChapter Create(Guid deviceChapId)
    {
        DevicesChapter devicesChapter = new DevicesChapter(deviceChapId);
        return devicesChapter;
    }

    public DevicesChapter(Guid deviceChapId, Guid subChapterGuid, Guid statusId,  string statusName, string brName, string dvName)
    {
        DeviceChapterId = deviceChapId;
        SubChapterId = subChapterGuid; 
        StatusId = statusId;
        StatusName = statusName;
        BrandName = brName;
        DeviceName = dvName;
    }

    public static DevicesChapter CreateProfile(Guid deviceChapId, Guid SubChapterGuid, Guid StatusId,
        string statusName, string brName, string dvName)
    {
        DevicesChapter devicesChapter = new DevicesChapter(deviceChapId, SubChapterGuid, StatusId, statusName, brName, dvName);
        return devicesChapter;
    }

    /// <summary>
    /// Конструктор DeviceChapter без дополнительных связных моделей с указание под-раздела
    /// </summary>
    /// <param name="deviceChapId">Индификатор DeviceChapter</param>
    /// <param name="subChapId">Индификатор подраздела</param>
    /// <param name="deviceId">Индификатор устройства (Название, Марка)</param>

    private DevicesChapter(
        Guid deviceChapId,
        Guid subChapId,
        Guid deviceId,
        Guid statusId,
        string serialNum,
        float countDevice,
        Guid? compId,
        string compName,
        DateTime reqProdDate,
        DateTime dateToFill,
        DateTime dateToEdit
    )
    {
        DeviceChapterId = deviceChapId;
        SubChapterId = subChapId;
        DeviceId = deviceId;
        StatusId = statusId;
        SerialNumber = serialNum;
        CountDevice = countDevice;
        CompId = compId;
        CompName = compName; 
        RequiredProdDate = reqProdDate;
        DateToFilling = dateToFill;
        DateToEditing = dateToEdit;
    }

    private DevicesChapter(
        Guid deviceChapId,
        Guid subChapId,
        Guid statusId,
        Guid deviceId,
        string serialNum,
        float countDevice,
        Guid? compId,
        string compName,
        DateTime dateToFill,
        DateTime dateToEdit,
        List<ConstructionDep> cdp,
        List<TmsDep> tmsDepPart,
        List<TcDep> tcDepPart,
        List<WarehouseDep> warehouseDepPart,
        List<AccountingDep> accountingDepPart
    )
    {
        DeviceChapterId = deviceChapId;
        SubChapterId = subChapId;
        StatusId = statusId;
        DeviceId = deviceId;
        SerialNumber = serialNum;
        DateToFilling = dateToFill;
        DateToEditing = dateToEdit;
        CountDevice = countDevice;
        CompId = compId;
        CompName = compName;
        ConstructionDepPart = cdp;
        TmsDepPart = tmsDepPart;
        TcDepPart = tcDepPart;
        WarehouseDepPart = warehouseDepPart;
        AccountingDepPart = accountingDepPart;
    }

    private DevicesChapter(
        Guid deviceChapId,
        Guid subChapId,
        Guid deviceId,
        Guid statusId,
        string serialNum,
        short statusRank,
        string deviceName,
        string brandName,
        string statusName,
        string depName,
        DateTime reqProdDate,
        DateTime dateToFill,
        DateTime dateToEdit,
        float countDevice,
        Guid? compId,
        string compName,
        List<ConstructionDep> cdp,
        List<TmsDep> tmsDepPart,
        List<TcDep> tcDepPart,
        List<WarehouseDep> warehouseDepPart,
        List<AccountingDep> accountingDepPart
    )
    {
        DeviceChapterId = deviceChapId;
        SubChapterId = subChapId;
        DeviceId = deviceId;
        SerialNumber = serialNum;
        DeviceName = deviceName;
        BrandName = brandName;
        StatusRank = statusRank;
        StatusId = statusId;
        StatusName = statusName;
        DepName = depName;
        CountDevice = countDevice;
        CompId = compId;
        CompName = compName;
        ConstructionDepPart = cdp;
        TmsDepPart = tmsDepPart;
        TcDepPart = tcDepPart;
        WarehouseDepPart = warehouseDepPart;
        AccountingDepPart = accountingDepPart;
        RequiredProdDate = reqProdDate;
        DateToFilling = dateToFill;
        DateToEditing = dateToEdit;
    }
    /// <summary>
    ///  Данные для формирования хаба уведомлений
    /// </summary>
    /// <param name="deviceChapId"></param>
    /// <param name="statusId"></param>
    /// <param name="deviceName"></param>
    /// <param name="brandName"></param>
    /// <param name="statusName"></param>
    private DevicesChapter(
        Guid deviceChapId,
        Guid subChapId,
        Guid statusId,
        string serialNum,
        string deviceName,
        string brandName,
        string statusName,
        float countDevice,
        Guid? compId,
        string compName
    )
    {
        DeviceChapterId = deviceChapId;
        SubChapterId = subChapId;
        DeviceName = deviceName;
        SerialNumber = serialNum;
        BrandName = brandName;
        StatusId = statusId;
        StatusName = statusName;
        CountDevice = countDevice;
        CompId = compId;
        CompName = compName;
    }

    public static DevicesChapter CreateNftData(
       Guid deviceChapId,
        Guid statusId,
        Guid subChapId,
        string serialNum,
        string deviceName,
        string brandName,
        string statusName,
        float countDevice,
        Guid? compId,
        string compName
   )
    {
        DevicesChapter devicesChapter = new DevicesChapter(
            deviceChapId,
            subChapId,
            statusId,
            serialNum,
            deviceName,
            brandName,
            statusName,
            countDevice,
            compId,
            compName
        );
        return devicesChapter;
    }

    public static (DevicesChapter dev, string err) Create(
        Guid deviceChapId,
        Guid subChapId,
        Guid deviceId,
        Guid statusId,
        string serialNum,
        float countDevice,
        Guid? compId,
        string compName,
        DateTime reqProdDate,
        DateTime dateToFill,
        DateTime dateToEdit
    )
    {
        DevicesChapter devicesChapter = new DevicesChapter(
            deviceChapId,
            subChapId,
            deviceId,
            statusId,
            serialNum,
            countDevice,
            compId,
            compName,
            reqProdDate,
            dateToFill,
            dateToEdit
        );
        return (devicesChapter, "Без ошибок");
    }

    public static (DevicesChapter dev, string err) CreateWithIncludes(
        Guid deviceChapId,
        Guid subChapId,
        Guid statusId,
        Guid deviceId,
        string serialNum,
        DateTime dateToFill,
        DateTime dateToEdit,
        float countDevice,
        Guid? compId,
        string compName,
        List<ConstructionDep> cdp,
        List<TmsDep> tmsDepPart,
        List<TcDep> tcDepPart,
        List<WarehouseDep> warehouseDepPart,
        List<AccountingDep> accountingDepPart
    )
    {
        DevicesChapter devicesChapter = new DevicesChapter(
            deviceChapId,
            subChapId,
            statusId,
            deviceId,
            serialNum,
            countDevice,
            compId,
            compName,
            dateToFill,
            dateToEdit,
            cdp,
            tmsDepPart,
            tcDepPart,
            warehouseDepPart,
            accountingDepPart
        );
        return (devicesChapter, "Без ошибок");
    }

    public static (DevicesChapter dev, string err) CreateWithIncludes1(
        Guid deviceChapId,
        Guid subChapId,
        Guid deviceId,
        Guid statusId,
        string serialNum,
        short statusRank,
        string deviceName,
        string brandName,
        string statusName,
        string depName,
        float countDevice,
        Guid? compId,
        string compName,
        List<ConstructionDep> cdp,
        List<TmsDep> tmsDepPart,
        List<TcDep> tcDepPart,
        List<WarehouseDep> warehouseDepPart,
        List<AccountingDep> accountingDepPart,
        DateTime reqProdDate,
        DateTime dateToFill,
        DateTime dateToEdit
    )
    {
        DevicesChapter devicesChapter = new DevicesChapter(
            deviceChapId,
            subChapId,
            deviceId,
            statusId,
            serialNum,
            statusRank,
            deviceName,
            brandName,
            statusName,
            depName,
            reqProdDate,
            dateToFill,
            dateToEdit,
            countDevice,
            compId,
            compName,
            cdp,
            tmsDepPart,
            tcDepPart,
            warehouseDepPart,
            accountingDepPart
           
        );
        return (devicesChapter, "Без ошибок");
    }

    /// <summary>
    /// Индификатора устройства
    /// </summary>
    public Guid DeviceChapterId { get; }

    public Guid DeviceId { get; }

    /// <summary>
    /// Заводские/Серийные номера
    /// </summary>
    public string SerialNumber { get; set; } = string.Empty;

    /// <summary>
    /// Кол-во требуемых устройств
    /// </summary>
    public float CountDevice { get; }
    /// <summary>
    /// Индификатор раздела
    /// </summary>

    // public Guid ChapterId { get; }

    /// <summary>
    /// Индификатор под-раздела
    /// </summary>

    public Guid SubChapterId { get; }


    public Guid StatusId { get; set; }
    public short StatusRank { get; set; }

    public string DeviceName { get; }

    public string BrandName { get; }

    public string StatusName { get; set; }
    public string DepName { get; set; }

    /// <summary>
    /// Дата Заполеннеия
    /// </summary>
    public DateTime DateToFilling { get; set; }

    /// <summary>
    /// Дата Редактирования
    /// </summary>
    public DateTime DateToEditing { get; set; }

    /// <summary>
    /// Требуемая дата поставки
    /// </summary>
    public DateTime RequiredProdDate { get; set; }

    /// <summary>
    /// Индификатор комплекта
    /// </summary>
    public Guid? CompId { get; set; }

    /// <summary>
    /// Наименование комплекта
    /// </summary>
    public string CompName { get; set; } = string.Empty;

    //public bool Visible { get; set; }

    public List<ConstructionDep> ConstructionDepPart { get; }
    public List<TmsDep> TmsDepPart { get; }
    public List<TcDep> TcDepPart { get; }
    public List<WarehouseDep> WarehouseDepPart { get; }
    public List<AccountingDep> AccountingDepPart { get; }
}
