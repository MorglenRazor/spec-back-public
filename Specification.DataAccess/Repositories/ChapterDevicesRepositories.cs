using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class ChapterDevicesRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<DevicesChapter>,
        IChapterDeviceRepository
{
    /// <summary>
    /// Ассинхронный запрос в БД на получение данных Устройства-раздела
    /// </summary>
    /// <returns>Список данных Устройства-раздела</returns>
    public async Task<List<DevicesChapter>> Get(Guid id)
    {
        
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        //devicesChapterEntities = await (from dc in DataBaseContext.DevicesChapter
        //                       //  where dc.DeviceChapterId==Guid.Empty? true : dc.DeviceChapterId==id
        //                         orderby dc.DateToFilling
        //                         select dc).ToListAsync();
        if (id == Guid.Empty)
        {
            devicesChapterEntities = await DataBaseContext
                .DevicesChapter.AsNoTracking()
                .OrderBy(o => o.DateToFilling)
                .ToListAsync();
        }
        else
        {
            devicesChapterEntities = await DataBaseContext
                .DevicesChapter.AsNoTracking().Where(f => f.DeviceChapterId == id)
                .OrderBy(o => o.DateToFilling)
                .ToListAsync();
        }

        List<DevicesChapter> devicesChapters = devicesChapterEntities
            .Select(s =>
                DevicesChapter
                    .Create(
                        deviceChapId: s.DeviceChapterId,
                        subChapId: s.SubChapterId,
                        deviceId: s.DeviceId,
                        statusId: s.StatusId,
                        serialNum: s.SerialNumber,
                        countDevice: s.CountDevice,
                        compId: s.CompId,
                        compName: s.CompName,
                        reqProdDate: s.RequiredProdDate,
                        dateToFill: s.DateToFilling,
                        dateToEdit: s.DateToEditing
                    )
                    .dev
            )
            .ToList();
        return devicesChapters;
    }

   public async Task<List<DevicesChapter>> GetNtfData()
    {
        //получить статусы по depId
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        //devicesChapterEntities =await (from dc in  DataBaseContext.DevicesChapter
        //                         join dev in DataBaseContext.Devices on dc.DeviceId equals dev.DeviceId
        //                         join cd in DataBaseContext.ConstructionDepartment on dc.DeviceChapterId equals cd.DeviceChapterId
        //                         join sts in DataBaseContext.StatusHandbook on dc.StatusId equals sts.Id
        //                           orderby dc.DateToFilling
        //                         select dc).ToListAsync();

        devicesChapterEntities = await DataBaseContext
                .DevicesChapter.AsNoTracking()
                .Include(i => i.Device)
                .Include(i => i.ConstructionDep)
                .Include(i => i.Status)
                .OrderBy(o => o.DateToFilling)
                .ToListAsync();

        List<DevicesChapter> devicesChapters = devicesChapterEntities
           .Select(s =>
               DevicesChapter
                   .CreateNftData(
                       deviceChapId: s.DeviceChapterId,
                        subChapId: s.SubChapterId,
                        brandName: s.Device == null ? "1" : s.Device.BrandName,
                        deviceName: s.Device == null ? "1" : s.Device.Name,
                        statusId: s.StatusId,
                        statusName: s.Status.Name,
                        countDevice: s.CountDevice,
                        compId: s.CompId,
                        compName: s.CompName,
                        serialNum: s.SerialNumber
                   )
           )
           .ToList();
     
        return devicesChapters;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на получение данных Устройства-раздела со связями
    /// </summary>
    /// <returns>Список данных Устройства-раздела с связующими данными</returns>
    public async Task<List<DevicesChapter>> GetWithIncludes(Guid id)
    {
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        

        if (id == Guid.Empty)
        {
            // devicesChapterEntities = await (
            //from dc in DataBaseContext.DevicesChapter.AsNoTracking()
            //join ad in (from accDep in DataBaseContext.AccountingDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on accDep.EmployerResponsibleId equals ed.Id
            //            select accDep)
            //    on dc.DeviceChapterId equals ad.DeviceChapterId
            //join wd in (from warhDep in DataBaseContext.WarehouseDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on warhDep.EmployerResponsibleId equals ed.Id
            //            select warhDep)
            //    on dc.DeviceChapterId equals wd.DeviceChapterId
            //join cd in (from cnsDep in DataBaseContext.ConstructionDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on cnsDep.EmployerResponsibleId equals ed.Id
            //            select cnsDep)
            //    on dc.DeviceChapterId equals cd.DeviceChapterId
            //join tcd in (from techCnDep in DataBaseContext.TcDepartment.AsNoTracking()
            //             join ed in DataBaseContext.Users on techCnDep.EmployerResponsibleId equals ed.Id
            //             select techCnDep)
            //    on dc.DeviceChapterId equals tcd.DeviceChapterId
            //join tms in (from tms_ in DataBaseContext.TmsDepartment.AsNoTracking()
            //             join ed in DataBaseContext.Users on tms_.EmployerResponsibleId equals ed.Id
            //             select tms_)
            //    on dc.DeviceChapterId equals tms.DeviceChapterId
            //join status in DataBaseContext.StatusHandbook on dc.StatusId equals status.Id
            //orderby dc.DateToFilling
            //select dc).ToListAsync();
            devicesChapterEntities = await DataBaseContext
                .DevicesChapter
                .AsNoTracking()
                .AsSingleQuery()
                .Include(i => i.AccountingDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.ConstructionDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.TechControlDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.TechMaterialSuppDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.Status)
                .OrderBy(o => o.DateToFilling)
                .ToListAsync();
        }
        else
        {
            //devicesChapterEntities = await (
            //from dc in DataBaseContext.DevicesChapter.AsNoTracking()
            //where dc.DeviceChapterId == id
            //join ad in (from accDep in DataBaseContext.AccountingDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on accDep.EmployerResponsibleId equals ed.Id
            //            select accDep)
            //    on dc.DeviceChapterId equals ad.DeviceChapterId
            //join wd in (from warhDep in DataBaseContext.WarehouseDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on warhDep.EmployerResponsibleId equals ed.Id
            //            select warhDep)
            //    on dc.DeviceChapterId equals wd.DeviceChapterId
            //join cd in (from cnsDep in DataBaseContext.ConstructionDepartment.AsNoTracking()
            //            join ed in DataBaseContext.Users on cnsDep.EmployerResponsibleId equals ed.Id
            //            select cnsDep)
            //    on dc.DeviceChapterId equals cd.DeviceChapterId
            //join tcd in (from techCnDep in DataBaseContext.TcDepartment.AsNoTracking()
            //             join ed in DataBaseContext.Users on techCnDep.EmployerResponsibleId equals ed.Id
            //             select techCnDep)
            //    on dc.DeviceChapterId equals tcd.DeviceChapterId
            //join tms in (from tms_ in DataBaseContext.TmsDepartment.AsNoTracking()
            //             join ed in DataBaseContext.Users on tms_.EmployerResponsibleId equals ed.Id
            //             select tms_)
            //    on dc.DeviceChapterId equals tms.DeviceChapterId
            //join status in DataBaseContext.StatusHandbook on dc.StatusId equals status.Id
            //orderby dc.DateToFilling
            //select dc).ToListAsync();
            devicesChapterEntities = await DataBaseContext
                .DevicesChapter.Where(f => f.DeviceChapterId == id)
                .AsNoTracking()
                .AsSingleQuery()
                .Include(i => i.AccountingDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.ConstructionDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.TechControlDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.TechMaterialSuppDep)
                .ThenInclude(i => i.EmployerData)
                .Include(i => i.Status)
                .OrderBy(o => o.DateToFilling)
                .ToListAsync();
        }

        //Console.WriteLine(devicesChapterEntities);
        List<DevicesChapter> devicesChapters = devicesChapterEntities
            .Select(s =>
                DevicesChapter
                    .CreateWithIncludes(
                        deviceChapId: s.DeviceChapterId,
                        subChapId: s.SubChapterId,
                        statusId: s.StatusId,
                        deviceId: s.DeviceId,
                        serialNum: s.SerialNumber,
                        dateToEdit: s.DateToEditing,
                        dateToFill: s.DateToFilling,
                        countDevice: s.CountDevice,
                        compId: s.CompId,
                        compName: s.CompName,
                        cdp: s.ConstructionDep.Select(s =>
                                ConstructionDep
                                    .Create(
                                        s.ConstructionDepId,
                                       // s.CountDevice,
                                        s.Comment,
                                        s.UnitId,
                                        s.EmployerResponsibleId,
                                        s.DeviceChapterId
                                    )
                                    .designPart
                            )
                            .ToList(),
                        tmsDepPart: s.TechMaterialSuppDep.Select(s =>
                                TmsDep
                                    .Create(
                                        s.TmsDepId,
                                        s.NameBrandForPurchase,
                                        s.Count,
                                       // s.DodContract,
                                        s.DodPlan,
                                        s.DodFact,
                                        s.PriceNoTax,
                                        s.PriceWithTax,
                                        s.Amount,
                                        s.AccountNumber,
                                        s.DateAccount,
                                        //s.FirstPay,
                                        //s.DateFirstPay,
                                        //s.SecondPay,
                                        //s.DateSecondPay,
                                        //s.ThirdPay,
                                        //s.DateThirdPay,
                                        //s.PaymentBalance,
                                        //s.CostOfRefand,
                                        s.Comment,
                                        s.DeviceChapterId,
                                        s.ContractorId,
                                        s.EmployerResponsibleId
                                    )
                                    .otms
                            )
                            .ToList(),
                        tcDepPart: s.TechControlDep.Select(s =>
                                TcDep
                                    .Create(
                                        s.TcDepId,
                                        s.NameBrandInDoc,
                                        s.Count,
                                        //s.SerialNum,
                                        s.CompKit,
                                        s.CompTechDocAvailable,
                                        s.CompTechDocMissing,
                                        s.Defects,
                                        s.Conclusion,
                                        s.Comment,
                                        s.UnitId,
                                        s.EmployerResponsibleId,
                                        s.DeviceChapterId
                                    )
                                    .otc
                            )
                            .ToList(),
                        warehouseDepPart: s.WarehouseDep.Select(s =>
                                WarehouseDep
                                    .Create(
                                        s.WarehouseDepId,
                                        s.CountOnStorage,
                                        s.CountAfterPurchase,
                                        s.RemainsCountAfterPurchase,
                                        //s.SerialNumber,
                                        //s.WriteOfDoc,
                                        //s.WriteOfDate,
                                        //s.AcceptSets,
                                        s.Comment,
                                        s.GenUnitId,
                                        s.RemainsUnitId,
                                        s.DeviceChapterId,
                                        s.EmployerResponsibleId
                                    )
                                    .storagePart
                            )
                            .ToList(),
                        accountingDepPart: s.AccountingDep.Select(s =>
                                AccountingDep
                                    .Create(
                                        s.AccountingDepId,
                                        s.NameBrandForUpd,
                                        s.CountFact,
                                        s.PriceOnOneTax,
                                        s.AmountTax,
                                        s.Article,
                                        s.DateDev,
                                        s.Price,
                                        s.AcompDoc,
                                        s.Comment,
                                        s.UnitId,
                                        s.EmployerResponsibleId,
                                        s.DeviceChapterId
                                    )
                                    .accountPart
                            )
                            .ToList()
                    )
                    .dev
            )
            .ToList();
        return devicesChapters;
    }

    public async Task<List<DevicesChapter>> GetDetails(Guid id)
    {
        List<DevicesChapterEntity> tempDevicesChapterEntities = new List<DevicesChapterEntity>();
        
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        List<DevicesChapterEntity> groupDevicesChapterEntities = new List<DevicesChapterEntity>();
        devicesChapterEntities = await DataBaseContext
            .DevicesChapter
            .AsNoTracking()
            .AsSingleQuery()
            .Include(i => i.Device)
            .Include(i => i.SubChapter)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.WarehouseDep)
             .ThenInclude(i => i.GenUom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.Contractor)
            .Include(i => i.Status)
            .ThenInclude(i => i.DepartmentCurrWork)
            .Where(f => f.CompId == null)
            .OrderBy(i=>i.DateToEditing)
            .ToListAsync();
        groupDevicesChapterEntities = await DataBaseContext
            .DevicesChapter
            //.Where(f=>f.ChapterId==id)
            .AsNoTracking()
             .AsSingleQuery()
            .Include(i => i.Device)
            .Include(i => i.SubChapter)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.WarehouseDep)
             .ThenInclude(i => i.GenUom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.Contractor)
            .Include(i => i.Status)
            .ThenInclude(i => i.DepartmentCurrWork)
            .Where(f => f.CompId != null).ToListAsync();
           var groupDevicesChapterEntities1 =  groupDevicesChapterEntities.GroupBy(g=> g.Device.BrandName).Select(s=> new DevicesChapterEntity
            {
               //BrandName = s.Key,
               Device = s.Select(ss=>ss.Device).FirstOrDefault(),
               AccountingDep = s.Select(ss => ss.AccountingDep).FirstOrDefault(),
               CompId = s.Select(ss => ss.CompId).FirstOrDefault(),
               CompName = s.Select(ss => ss.CompName).FirstOrDefault(),
               ConstructionDep = s.Select(ss => ss.ConstructionDep).FirstOrDefault(),
               CountDevice = s.Sum((ss=>ss.CountDevice)),
               DateToEditing = s.Select(ss => ss.DateToEditing).FirstOrDefault(),
               DateToFilling = s.Select(ss => ss.DateToFilling).FirstOrDefault(),
               DeviceChapterId = s.Select(ss => ss.DeviceChapterId).FirstOrDefault(),
               DeviceId = s.Select(ss => ss.DeviceId).FirstOrDefault(),
               RequiredProdDate = s.Select(ss => ss.RequiredProdDate).FirstOrDefault(),
               Status = s.Select(ss => ss.Status).FirstOrDefault(),
               StatusId = s.Select(ss => ss.StatusId).FirstOrDefault(),
               SubChapter = s.Select(ss => ss.SubChapter).FirstOrDefault(),
               SubChapterId = s.Select(ss => ss.SubChapterId).FirstOrDefault(),
               TechControlDep = s.Select(ss => ss.TechControlDep).FirstOrDefault(),
               TechMaterialSuppDep = s.Select(ss => ss.TechMaterialSuppDep).FirstOrDefault(),
               WarehouseDep = s.Select(ss => ss.WarehouseDep).FirstOrDefault()
           })
          //  .OrderBy(i => i.DateToEditing)
            .ToList();
        Console.WriteLine(devicesChapterEntities);
        Console.WriteLine(groupDevicesChapterEntities1);
        tempDevicesChapterEntities.AddRange(devicesChapterEntities);
        tempDevicesChapterEntities.AddRange(groupDevicesChapterEntities1);
     
        List<DevicesChapter> devicesChapters = tempDevicesChapterEntities.OrderBy(o=>o.DateToEditing)
            .Select(s =>
                DevicesChapter
                    .CreateWithIncludes1(
                        deviceChapId: s.DeviceChapterId,
                        subChapId: s.SubChapterId,
                        deviceId: s.DeviceId,
                        serialNum: s.SerialNumber,
                        brandName: s.Device == null ? "1" : s.Device.BrandName,
                        deviceName: s.Device == null ? "1" : s.Device.Name,
                        statusId: s.StatusId,
                        statusName: s.Status.Name,
                        statusRank: s.Status.Rank,
                        dateToEdit: s.DateToEditing,
                        dateToFill: s.DateToFilling,
                        depName: s.Status.DepartmentCurrWork.ShortName,
                        countDevice: s.CountDevice,
                        compId: s.CompId,
                        compName: s.CompName,
                        reqProdDate: s.RequiredProdDate,
                        cdp: s.ConstructionDep.Select(s =>
                                ConstructionDep
                                    .Create(
                                        s.ConstructionDepId,
                                       // s.CountDevice,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        s.UnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .designPart
                            )
                            .ToList(),
                        tmsDepPart: s.TechMaterialSuppDep.Select(ss =>
                                TmsDep
                                    .Create(
                                        ss.TmsDepId,
                                        ss.NameBrandForPurchase,
                                        ss.Count,
                                      //  ss.DodContract,
                                        ss.DodPlan,
                                        ss.DodFact,
                                        ss.PriceNoTax,
                                        ss.PriceWithTax,
                                        ss.Amount,
                                        ss.AccountNumber,
                                        ss.DateAccount,
                                        //ss.FirstPay,
                                        //ss.DateFirstPay,
                                        //ss.SecondPay,
                                        //ss.DateSecondPay,
                                        //ss.ThirdPay,
                                        //ss.DateThirdPay,
                                        //ss.PaymentBalance,
                                        //ss.CostOfRefand,
                                        ss.Comment,
                                        ss.DeviceChapterId,
                                        ss.Contractor.ContractorName,
                                        ss.Contractor.Inn,
                                        ss.EmployerData == null ? "" : ss.EmployerData.ShortName,
                                        ss.ContractorId,
                                        ss.EmployerResponsibleId
                                    )
                                    .otms
                            )
                            .ToList(),
                        tcDepPart: s.TechControlDep.Select(s =>
                                TcDep
                                    .Create(
                                        s.TcDepId,
                                        s.NameBrandInDoc,
                                        s.Count,
                                       // s.SerialNum,
                                        s.CompKit,
                                        s.CompTechDocAvailable,
                                        s.CompTechDocMissing,
                                        s.Defects,
                                        s.Conclusion,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        s.UnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .otc
                            )
                            .ToList(),
                        warehouseDepPart: s.WarehouseDep.Select(s =>
                                WarehouseDep
                                    .Create(
                                        s.WarehouseDepId,
                                        s.CountOnStorage,
                                        s.CountAfterPurchase,
                                        s.RemainsCountAfterPurchase,
                                        //s.SerialNumber,
                                        //s.WriteOfDoc,
                                        //s.WriteOfDate,
                                        //s.AcceptSets,
                                        s.Comment,
                                        s.GenUom.ShortName,
                                        s.Uom.ShortName,
                                        s.DeviceChapterId,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.GenUnitId,
                                        s.RemainsUnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .storagePart
                            )
                            .ToList(),
                        accountingDepPart: s.AccountingDep.Select(s =>
                                AccountingDep
                                    .Create(
                                        s.AccountingDepId,
                                        s.NameBrandForUpd,
                                        s.CountFact,
                                        s.PriceOnOneTax,
                                        s.AmountTax,
                                        s.Article,
                                        s.DateDev,
                                        s.Price,
                                        s.AcompDoc,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        unitId: s.UnitId,
                                        empRespId: s.EmployerResponsibleId
                                    )
                                    .accountPart
                            )
                            .ToList()
                    )
                    .dev
            )
            .ToList();

        return devicesChapters;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на добавление данных Устройства-раздела в спецификацию
    /// </summary>
    /// <param name="model">Заполененая модель данных</param>
    public async Task Add(DevicesChapter model)
    {
        DevicesChapterEntity devicesChapterEntity = new DevicesChapterEntity
        {
            DeviceChapterId = model.DeviceChapterId,
            SubChapterId = model.SubChapterId,
            DeviceId = model.DeviceId,
            CountDevice= model.CountDevice,
            CompId = model.CompId,
            CompName = model.CompName,
            StatusId = model.StatusId,
            RequiredProdDate = model.RequiredProdDate,
            DateToEditing = model.DateToEditing,
            DateToFilling = model.DateToFilling,
        };

        await DataBaseContext.AddAsync(devicesChapterEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Ассинхронный запрос в БД на обновление данных Устройства-раздела
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <param name="model">Заполененая модель с обновленными данными</param>
    public async Task Update(Guid id, DevicesChapter model)
    {
        await DataBaseContext
            .DevicesChapter.Where(f => f.DeviceChapterId == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.DeviceChapterId, model.DeviceChapterId)
                    .SetProperty(s => s.SubChapterId, model.SubChapterId)
                    .SetProperty(s=>s.DateToEditing, model.DateToEditing)
                    .SetProperty(s => s.StatusId, model.StatusId)
                    .SetProperty(s=>s.CountDevice, model.CountDevice)
            );
    }

    public async Task UpdateCountDevice(Guid id, float count)
    {
        await DataBaseContext
            .DevicesChapter.Where(f => f.DeviceChapterId == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.CountDevice, count)                    
            );
    }

    public async Task UpdateStatus(Guid id, Guid status)
    {
        await DataBaseContext.DevicesChapter
            .Where(f => f.DeviceChapterId == id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.StatusId, status));
    }

    public async Task UpdateSerialNumber(Guid devceChapId, string serialNum)
    {
        await DataBaseContext.DevicesChapter
            .Where(f => f.DeviceChapterId == devceChapId)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.SerialNumber, serialNum));
    }

    /// <summary>
    /// Ассинхронный запрос в БД на удаление данных Устройства-раздела
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    public async Task Delete(Guid id) =>
        await DataBaseContext
            .DevicesChapter.Where(f => f.DeviceChapterId == id)
            .ExecuteDeleteAsync();

 
    public async Task<Guid> CreateChapterDetail(DevicesChapter model)
    {
        var newGuid = Guid.NewGuid();
        DevicesChapterEntity devicesChapterEntity = new DevicesChapterEntity
        {
            DeviceChapterId = newGuid,
            SubChapterId = model.SubChapterId,
            CountDevice = model.CountDevice,
            CompId = model.CompId,
            CompName = model.CompName,
            DeviceId = model.DeviceId,
            StatusId = model.StatusId,
            DateToEditing = model.DateToEditing,
            DateToFilling = model.DateToFilling
        };

        await DataBaseContext.AddAsync(devicesChapterEntity);
        await DataBaseContext.SaveChangesAsync();
        return newGuid;
    }

    public async Task<List<DevicesChapter>> GetDeviceChaptersId(Guid id)
    {
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        devicesChapterEntities = await DataBaseContext
                .DevicesChapter.AsNoTracking()
                .ToListAsync();
        List<DevicesChapter> devicesChapters = devicesChapterEntities
           .Select(s =>
               DevicesChapter
                   .Create(
                       deviceChapId: s.DeviceChapterId
                   )
           )
           .ToList();
        return devicesChapters;
    }
    /// <summary>
    /// Получение группы устройств по deviceChapterId
    /// </summary>
    /// <param name="deviceChapterId"></param>
    /// <returns></returns>
    public async Task<List<DevicesChapter>> GetGroupDeviceChapters(Guid deviceChapterId)
    {
        List<DevicesChapterEntity> devicesChapterEntities = new List<DevicesChapterEntity>();
        devicesChapterEntities = await DataBaseContext
            .DevicesChapter
            .AsNoTracking()
            .AsSingleQuery()
            .Include(i => i.Device)
            .Include(i => i.SubChapter)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.AccountingDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.WarehouseDep)
             .ThenInclude(i => i.GenUom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.Uom)
            .Include(i => i.WarehouseDep)
                .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.ConstructionDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.Uom)
            .Include(i => i.TechControlDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.EmployerData)
            .Include(i => i.TechMaterialSuppDep)
            .ThenInclude(i => i.Contractor)
            .Include(i => i.Status)
            .ThenInclude(i => i.DepartmentCurrWork)
            .Where(f => f.DeviceChapterId == deviceChapterId || f.CompId == deviceChapterId)
            .OrderBy(i => i.DateToEditing)
            .ToListAsync();
        List<DevicesChapter> devicesChapters = devicesChapterEntities.OrderByDescending(o => o.CompName).ThenBy(o => o.DateToEditing)
            .Select(s =>
                DevicesChapter
                    .CreateWithIncludes1(
                        deviceChapId: s.DeviceChapterId,
                        subChapId: s.SubChapterId,
                        deviceId: s.DeviceId,
                        serialNum:s.SerialNumber,
                        brandName: s.Device == null ? "1" : s.Device.BrandName,
                        deviceName: s.Device == null ? "1" : s.Device.Name,
                        statusId: s.StatusId,
                        statusName: s.Status.Name,
                        statusRank: s.Status.Rank,
                        dateToEdit: s.DateToEditing,
                        dateToFill: s.DateToFilling,
                        depName: s.Status.DepartmentCurrWork.ShortName,
                        countDevice: s.CountDevice,
                        compId: s.CompId,
                        compName: s.CompName,
                        reqProdDate: s.RequiredProdDate,
                        cdp: s.ConstructionDep.Select(s =>
                                ConstructionDep
                                    .Create(
                                        s.ConstructionDepId,
                                        // s.CountDevice,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        s.UnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .designPart
                            )
                            .ToList(),
                        tmsDepPart: s.TechMaterialSuppDep.Select(ss =>
                                TmsDep
                                    .Create(
                                        ss.TmsDepId,
                                        ss.NameBrandForPurchase,
                                        ss.Count,
                                        //  ss.DodContract,
                                        ss.DodPlan,
                                        ss.DodFact,
                                        ss.PriceNoTax,
                                        ss.PriceWithTax,
                                        ss.Amount,
                                        ss.AccountNumber,
                                        ss.DateAccount,
                                       // ss.FirstPay,
                                        //ss.DateFirstPay,
                                        //ss.SecondPay,
                                        //ss.DateSecondPay,
                                        //ss.ThirdPay,
                                        //ss.DateThirdPay,
                                        //ss.PaymentBalance,
                                        //ss.CostOfRefand,
                                        ss.Comment,
                                        ss.DeviceChapterId,
                                        ss.Contractor.ContractorName,
                                        ss.Contractor.Inn,
                                        ss.EmployerData == null ? "" : ss.EmployerData.ShortName,
                                        ss.ContractorId,
                                        ss.EmployerResponsibleId
                                    )
                                    .otms
                            )
                            .ToList(),
                        tcDepPart: s.TechControlDep.Select(s =>
                                TcDep
                                    .Create(
                                        s.TcDepId,
                                        s.NameBrandInDoc,
                                        s.Count,
                                        //s.SerialNum,
                                        s.CompKit,
                                        s.CompTechDocAvailable,
                                        s.CompTechDocMissing,
                                        s.Defects,
                                        s.Conclusion,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        s.UnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .otc
                            )
                            .ToList(),
                        warehouseDepPart: s.WarehouseDep.Select(s =>
                                WarehouseDep
                                    .Create(
                                        s.WarehouseDepId,
                                        s.CountOnStorage,
                                        s.CountAfterPurchase,
                                        s.RemainsCountAfterPurchase,
                                        //s.SerialNumber,
                                        //s.WriteOfDoc,
                                        //s.WriteOfDate,
                                        //s.AcceptSets,
                                        s.Comment,
                                        s.GenUom.ShortName,
                                        s.Uom.ShortName,
                                        s.DeviceChapterId,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.GenUnitId,
                                        s.RemainsUnitId,
                                        s.EmployerResponsibleId
                                    )
                                    .storagePart
                            )
                            .ToList(),
                        accountingDepPart: s.AccountingDep.Select(s =>
                                AccountingDep
                                    .Create(
                                        s.AccountingDepId,
                                        s.NameBrandForUpd,
                                        s.CountFact,
                                        s.PriceOnOneTax,
                                        s.AmountTax,
                                        s.Article,
                                        s.DateDev,
                                        s.Price,
                                        s.AcompDoc,
                                        s.Comment,
                                        s.Uom.ShortName,
                                        s.EmployerData == null ? "" : s.EmployerData.ShortName,
                                        s.DeviceChapterId,
                                        unitId: s.UnitId,
                                        empRespId: s.EmployerResponsibleId
                                    )
                                    .accountPart
                            )
                            .ToList()
                    )
                    .dev
            )
            .ToList();
        return devicesChapters;
    }

    
}
