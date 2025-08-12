using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories
{
    public class SubChapterRepositories(SpecificationDataBaseContext dbContext)
        : BaseRepositories(dbContext),
            ITableRepository<SubChapter>,
            ISubChapterRepository
    {
        public async Task Add(SubChapter model)
        {
            SubChapterEntity entity = new SubChapterEntity
            {
                SubChapId = model.SubChapId,
                ChapterId = model.ChapterId,
                CategoryDeviceId = model.CategoryDeviceId,
            };
            await DataBaseContext.AddAsync(entity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.SubChapters.Where(f => f.SubChapId == id).ExecuteDeleteAsync();
        }

        public async Task<List<SubChapter>> Get(Guid id)
        {
            List<SubChapterEntity> subChapters = new List<SubChapterEntity>();
            subChapters = await DataBaseContext.SubChapters.AsNoTracking().ToListAsync();
            List<SubChapter> subChaptersList = subChapters
                .Select(s =>
                    SubChapter
                        .Create(sChId: s.SubChapId, CdId: s.CategoryDeviceId, chId: s.ChapterId)
                        .sch
                )
                .ToList();
            return subChaptersList;
        }

        public async Task<List<SubChapter>> GetSubChapterDetail()
        {
            List<SubChapterEntity> subChapters = new List<SubChapterEntity>();
            subChapters = await DataBaseContext
                .SubChapters.AsNoTracking()
                .Include(i => i.CategoryDevice)
                .ToListAsync();
            List<SubChapter> subChaptersList = subChapters
                .Select(s =>
                    SubChapter
                        .Create(
                            sChId: s.SubChapId,
                            CdId: s.CategoryDeviceId,
                            chId: s.ChapterId,
                            categoryName: s.CategoryDevice.Name
                        )
                        .sch
                )
                .ToList();
            return subChaptersList;
        }

        public async Task<List<SubChapter>> GetSubChapterProfile(List<Guid> statusIds)
        {
            List<SubChapterEntity> subChapters = new List<SubChapterEntity>();
            subChapters = await DataBaseContext
                .SubChapters.AsNoTracking()
                .Include(i=>i.ChapterEntity).ThenInclude(i=>i.Specification)
                .Include(i=>i.ChapterEntity).ThenInclude(i=>i.CategoryChapter)
                .Include(i=>i.Devices)
                .Include(i => i.CategoryDevice)
                .Include(i=>i.Devices).ThenInclude(i=>i.Status)
                .Include(i=>i.Devices).ThenInclude(i=>i.Device)
                .ToListAsync();
           
            List<SubChapter> subChaptersList = new();

            foreach (var subChap in subChapters)    //4
            {
                List<DevicesChapter> tempDev = new();
                foreach (var dev in subChap.Devices)
                {
                  
                    foreach (var item in statusIds)
                    {
                        if (item == dev.StatusId)
                        {
                            if (subChap.SubChapId == dev.SubChapterId)
                            {
                                tempDev.Add(DevicesChapter.CreateProfile(
                                         dev.DeviceChapterId,
                                         dev.SubChapterId,
                                         dev.StatusId,
                                         dev.Status.Name,
                                         dev.Device.BrandName,
                                         dev.Device.Name));

                            }
                            

                        }
                    }

                }
                if (tempDev.Count > 0)
                {
                    subChaptersList.Add(
                              SubChapter
                              .CreateProfile(
                                  subChapId: subChap.SubChapId,
                                  catId: subChap.CategoryDeviceId,
                                  chId: subChap.ChapterId,
                                  catChapName: subChap.ChapterEntity.CategoryChapter.Name,
                                  specId: subChap.ChapterEntity.SpecificationId,
                                  catName: subChap.CategoryDevice.Name,
                                  countDevice: subChap.Devices.Count,
                                  specName: subChap.ChapterEntity.Specification.Name,
                                  devices: tempDev
                              ).sch);
                }
                
            }
           
            Console.WriteLine(subChaptersList);
            return subChaptersList;
        }

        public async Task Update(Guid id, SubChapter model)
        {
            await DataBaseContext
                .SubChapters.Where(f => f.SubChapId == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(s => s.CategoryDeviceId, model.CategoryDeviceId)
                        .SetProperty(s => s.ChapterId, model.ChapterId)
                );
        }
    }
}
