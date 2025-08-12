using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class SpecificationRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<Core.Models.Specification>,
        ISpecificationRepository
{
    /// <summary>
    /// Асинхронный метод добавления данных в таблицу SpecificationEntity
    /// </summary>
    /// <param name="specification">Заполенения модель Specification</param>
    /// <returns>Индификатор добавленой записи</returns>
    public async Task Add(Core.Models.Specification specification)
    {
       
        List<ChapterEntity> chapEnt = new List<ChapterEntity>();
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = Guid.NewGuid(),
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("408548d9-2c09-4648-b199-77e449be271d")
        });
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = Guid.NewGuid(),
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("65588ece-b6c8-446d-adac-e503c2a009d1")
        });
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = Guid.NewGuid(),
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("d8f69440-3626-4f2c-acde-46b623ebc12b")
        });
        SpecificationEntity specEntity = new SpecificationEntity
        {
            SpecId = specification.SpecificationId,
            Readiness = specification.Readiness,
            DateCreate = DateTime.Now,
            TotalUncoverPos = specification.TotalUncoverPos,
            NumWork = specification.NumWork,
            Name = specification.Name,
            NumTask = specification.NumTask,
            CustomerId = specification.CustomerSpecId,
            Chapters = chapEnt
        };

        await DataBaseContext.AddAsync(specEntity);
        await DataBaseContext.SaveChangesAsync();
    }


    /// <summary>
    /// Асинхронный метод обновления данных из таблицу SpecificationEntity
    /// </summary>
    /// <param name="specId">Индификатор редактируемй записи</param>
    /// <param name="specification">Заполенения модель Specification</param>
    /// <returns>Индификатор обновленой записи</returns>
    public async Task Update(Guid specId, Core.Models.Specification specification)
    {
        await DataBaseContext
            .Specifications.Where(s => s.SpecId == specId)
            .ExecuteUpdateAsync(s =>
                //s.SetProperty(s => s.Readiness, specification.Readiness)
                  //  .SetProperty(s => s.TotalUncoverPos, specification.TotalUncoverPos)
                    s.SetProperty(s => s.NumWork, specification.NumWork)
                    .SetProperty(s => s.NumTask, specification.NumTask)
                    .SetProperty(s => s.Name, specification.Name)
                    .SetProperty(s => s.CustomerId, specification.CustomerSpecId)
            );
    }

    /// <summary>
    /// Асинхронный метод удаления данных из таблицу SpecificationEntity
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Индификатор удаленной  записи</returns>
    public async Task Delete(Guid id)
    {
        await DataBaseContext.Specifications.Where(s => s.SpecId == id).ExecuteDeleteAsync();
    }

    /// <summary>
    /// Асинхронный метод получения данных таблицы SpecificationEntity из БД
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <returns>Возвращает список </returns>
    public async Task<List<Core.Models.Specification>> Get(Guid id)
    {
        List<SpecificationEntity> specEntity = new List<SpecificationEntity>();

        if (id == Guid.Empty)
        {
            specEntity = await DataBaseContext
                .Specifications.AsNoTracking()
                .Include(i => i.Chapters)
                    .ThenInclude(i => i.SubChapters)
                    .ThenInclude(i => i.Devices)
                .Include(i => i.Customer)
                .OrderByDescending(o=>o.DateCreate)
                .ToListAsync();
        }
        else
        {
            specEntity = await DataBaseContext
                .Specifications.Where(f => f.SpecId == id)
                .AsNoTracking()
                .Include(i => i.Customer).OrderByDescending(o => o.DateCreate)
                .ToListAsync();
        }

        var t1 = 0;
        double countDeviceToReady = 0;
        double countDevice = 0;
        foreach (var spec in specEntity)
        {
            foreach (var chap in spec.Chapters)
            {
                foreach (var subChap in chap.SubChapters)
                {
                   
                    foreach (var device in subChap.Devices)
                    {
                        countDevice++;
                        t1++;
                        if (device.StatusId == Guid.Parse("58b8a091-395f-45b0-ab95-7b7757ed5a81"))
                        {
                            countDeviceToReady++;
                            t1--;
                        }
                       
                    }
                    
                }
            }
        }

        double c = 0;
        c = (countDeviceToReady / countDevice);
        double readness = (countDeviceToReady / countDevice) * 100;

        List<Core.Models.Specification> specList = specEntity
            .Select(s =>
            {
                return Core.Models.Specification.Create(
                                    id: s.SpecId,
                                    numWork: s.NumWork,
                                    numTask: s.NumTask,
                                    name: s.Name,
                                    totalUncoverPos: t1,
                                    readiness: (int)readness,
                                    cusId: s.CustomerId,
                                    cusName: s.Customer.Name
                                ).Spec;
            })
            .ToList();
        return specList;
    }

    //public async Task<int> Get(Guid id)
    //{
    //    List<SpecificationEntity> specEntity = new List<SpecificationEntity>();

    //    specEntity = await DataBaseContext
    //            .Specifications.Where(f => f.SpecId == id)
    //            .AsNoTracking()
    //            .Include(i=>i.Chapters).ThenInclude(i=>i.SubChapters).ThenInclude(i=>i.Devices)
    //            .Include(i => i.Customer).OrderByDescending(o => o.DateCreate)
    //            .ToListAsync();
    //    List<Core.Models.Specification> specList = specEntity
    //        .Select(s =>
    //            Core.Models.Specification.Create(
    //                id: s.SpecId,
    //                numWork: s.NumWork,
    //                numTask: s.NumTask,
    //                name: s.Name,
    //                totalUncoverPos: s.Chapters.Select(s=>s.SubChapters.Select(ss=>ss.Devices.Select(s=>s.DeviceId).Count())).Count(),
    //                readiness: s.Readiness,
    //                cusId: s.CustomerId,
    //                cusName: s.Customer.Name
    //            ).Spec
    //        )
    //        .ToList();
    //    return 0;
    //}

    public async Task<Core.Models.Specification> AddWthReturnChapIds(Core.Models.Specification specification)
    {
        List<Chapter> chapterIdsRtn = new List<Chapter>();

        List<ChapterEntity> chapEnt = new List<ChapterEntity>();
        chapterIdsRtn.Add(Chapter.Create(Guid.NewGuid(), Guid.Parse("408548d9-2c09-4648-b199-77e449be271d")));
        chapterIdsRtn.Add(Chapter.Create(Guid.NewGuid(), Guid.Parse("65588ece-b6c8-446d-adac-e503c2a009d1")));
        chapterIdsRtn.Add(Chapter.Create(Guid.NewGuid(), Guid.Parse("d8f69440-3626-4f2c-acde-46b623ebc12b")));
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = chapterIdsRtn[0].ChapterId,
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("408548d9-2c09-4648-b199-77e449be271d")
        });
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = chapterIdsRtn[1].ChapterId,
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("65588ece-b6c8-446d-adac-e503c2a009d1")
        });
        chapEnt.Add(new ChapterEntity
        {
            ChapterId = chapterIdsRtn[2].ChapterId,
            Comment = "",
            CostChapter = 0,
            Readiness = 0,
            SpecificationId = specification.SpecificationId,
            CategoryChapterId = Guid.Parse("d8f69440-3626-4f2c-acde-46b623ebc12b")
        });
        SpecificationEntity specEntity = new SpecificationEntity
        {
            SpecId = specification.SpecificationId,
            Readiness = specification.Readiness,
            DateCreate = DateTime.Now,
            TotalUncoverPos = specification.TotalUncoverPos,
            NumWork = specification.NumWork,
            Name = specification.Name,
            NumTask = specification.NumTask,
            CustomerId = specification.CustomerSpecId,
            Chapters = chapEnt
        };

        await DataBaseContext.AddAsync(specEntity);
        await DataBaseContext.SaveChangesAsync();

        return Core.Models.Specification.Create(specification.SpecificationId, chapterIdsRtn).Spec;
    }
}
