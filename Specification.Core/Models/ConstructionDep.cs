namespace Specification.Core.Models;

public class ConstructionDep
{
    private ConstructionDep(
        int id,
        //float cd,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chpDeviceId
    )
    {
        ConstructionDepId = id;
        //CountDevice = cd;
        UnitId = unitId;
        EmpRespId = empRespId;
        ChapterDeviceId = chpDeviceId;
        Comment = comment;
    }

    private ConstructionDep(
        int id,
       // float cd,
        string comment,
        string unitNameCd,
        string respShortName,
        Guid chpDeviceId,
        int unitId,
        Guid? empRespId
    )
    {
        ConstructionDepId = id;
      //  CountDevice = cd;
        UnitNameCd = unitNameCd;
        ChapterDeviceId = chpDeviceId;
        EmpShortName = respShortName;
        Comment = comment;
        UnitId = unitId;
        EmpRespId = empRespId;
    }

    /// <summary>
    /// Создание модели
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cd">Кол-во требуемых устройств</param>
    /// <param name="comment">Примечание</param>
    /// <param name="unitId">Ед.изм</param>
    /// <param name="chpDeviceId"></param>
    /// <returns></returns>
    public static (ConstructionDep designPart, string err) Create(
        int id,
      //  float cd,
        string comment,
        int unitId,
        Guid? empRespId,
        Guid chpDeviceId
    )
    {
        ConstructionDep constructionDep = new ConstructionDep(
            id,
         //   cd,
            comment,
            unitId,
            empRespId,
            chpDeviceId
        );
        return (constructionDep, "Без ошибок");
    }

    public static (ConstructionDep designPart, string err) Create(
        int id,
       // float cd,
        string comment,
        string unitNameCd,
        string empShortName,
        Guid chpDeviceId,
        int unitCd,
        Guid? empRespId
    )
    {
        ConstructionDep constructionDep = new ConstructionDep(
            id,
        //    cd,
            comment,
            unitNameCd,
            empShortName,
            chpDeviceId,
            unitCd,
            empRespId
        );
        return (constructionDep, "Без ошибок");
    }

    //Старый Create с CheckOnStorage & PurchaseToBuy
    // public static (ConstructionDep designPart, string err) Create(int id, bool cos, bool ptb,
    //     DateTime dtf, float cd, string comment, int unitId, Guid chpDeviceId)
    // {
    //     ConstructionDep constructionDep = new ConstructionDep(id, cos, ptb, dtf, cd, comment,
    //         unitId, chpDeviceId);
    //     return (constructionDep, "Без ошибок");
    // }

    public int ConstructionDepId { get; }


    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = String.Empty;

    public int UnitId { get; }
    public string UnitNameCd { get; }

    public Guid? EmpRespId { get; }
    public string EmpShortName { get; }
    public Guid ChapterDeviceId { get; }
}
