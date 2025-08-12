using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class WarehouseDepRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<WarehouseDep>
{
    public async Task<List<WarehouseDep>> Get()
    {
        List<WarehouseDepartmentEntity> warehouseDepEntities = await DataBaseContext
            .WarehouseDepartment.AsNoTracking()
            .Include(i => i.GenUom)
            .Include(i => i.Uom)
            .ToListAsync();
        List<WarehouseDep> warehouseDepParts = warehouseDepEntities
            .Select(s =>
                WarehouseDep
                    .Create(
                        id: s.WarehouseDepId,
                        // eos: s.ExistOnStorage,
                        cos: s.CountOnStorage,
                        cap: s.CountAfterPurchase,
                        rCap: s.RemainsCountAfterPurchase,
                        //sNum: s.SerialNumber,
                        //wod: s.WriteOfDoc,
                        //wodt: s.WriteOfDate,
                        //acs: s.AcceptSets,
                        comment: s.Comment,
                        getUnitId: s.GenUnitId,
                        dopUnitId: s.RemainsUnitId,
                        chpDeviceId: s.DeviceChapterId,
                        empRespId: s.EmployerResponsibleId
                    )
                    .storagePart
            )
            .ToList();

        return warehouseDepParts;
    }

    public async Task Add(WarehouseDep model)
    {
        WarehouseDepartmentEntity warehouseDepartmentEntity = new WarehouseDepartmentEntity
        {
            //ExistOnStorage = model.ExistOnStorage,
            CountOnStorage = model.CountOnStorage,
            CountAfterPurchase = model.CountAfterPurchase,
            RemainsCountAfterPurchase = model.RemainsCountAfterPurchase,
            //SerialNumber = model.SerialNumber,
            WriteOfDoc = "",
            WriteOfDate = DateTime.Now,
            AcceptSets = "",
            Comment = model.Comment,
            GenUnitId = model.GenUnitId,
            RemainsUnitId = model.RemainsUnitId,
            DeviceChapterId = model.ChapterDeviceId,
            EmployerResponsibleId = model.EmpRespId,
        };

        await DataBaseContext.AddAsync(warehouseDepartmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    public async Task Update(int id, WarehouseDep model)
    {
        await DataBaseContext
            .WarehouseDepartment.Where(f => f.WarehouseDepId == id)
            .ExecuteUpdateAsync(e =>
                e
                //  .SetProperty(s => s.ExistOnStorage, model.ExistOnStorage)
                .SetProperty(s => s.CountOnStorage, model.CountOnStorage)
                    .SetProperty(s => s.CountAfterPurchase, model.CountAfterPurchase)
                    .SetProperty(s => s.RemainsCountAfterPurchase, model.RemainsCountAfterPurchase)
                    //.SetProperty(s => s.SerialNumber, model.SerialNumber)
                    .SetProperty(s => s.Comment, model.Comment)
                    .SetProperty(s => s.GenUnitId, model.GenUnitId)
                    .SetProperty(s => s.RemainsUnitId, model.RemainsUnitId)
                    .SetProperty(s => s.DeviceChapterId, model.ChapterDeviceId)
                    .SetProperty(s=>s.EmployerResponsibleId, model.EmpRespId)
            );
    }

    public async Task Delete(int id) =>
        await DataBaseContext
            .WarehouseDepartment.Where(f => f.WarehouseDepId == id)
            .ExecuteDeleteAsync();
}
