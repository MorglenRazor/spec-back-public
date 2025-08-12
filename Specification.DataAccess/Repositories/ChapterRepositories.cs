using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class ChapterRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<Chapter>,
        IChapterRepository
{
    /// <summary>
    /// Асинхрнонный метод добавления данных таблицы ChapterEntity в базу данных
    /// </summary>
    /// <param name="chapter">Модель Chapter</param>
    /// <returns>Индификатор добавленой записи</returns>
    public async Task Add(Chapter chapter)
    {
        ChapterEntity chapterEntity = new ChapterEntity
        {
            ChapterId = chapter.ChapterId,
            Readiness = chapter.Readiness,
            CategoryChapterId = chapter.CategoryChapterId,
            SpecificationId = chapter.SpecificationId,
        };

        await DataBaseContext.AddAsync(chapterEntity);
        await DataBaseContext.SaveChangesAsync();
    }


    /// <summary>
    /// Асинхрнонный метод добавления данных таблицы ChapterEntity в базу данных
    /// </summary>
    /// <param name="chapter">Модель Chapter</param>
    /// <returns>Индификатор добавленой записи</returns>
    public async Task AddWithSubChapters(Chapter chapter)
    {
        ChapterEntity chapterEntity = new ChapterEntity
        {
            ChapterId = chapter.ChapterId,
            Readiness = chapter.Readiness,
            SpecificationId = chapter.SpecificationId,
            CategoryChapterId = chapter.CategoryChapterId,
            SubChapters = chapter.SubChapters.Select(s => new SubChapterEntity
            {
                ChapterId = chapter.ChapterId,
                CategoryDeviceId = s.CategoryDeviceId,
                SubChapId = s.SubChapId,
            }).ToList()
        };

        await DataBaseContext.AddAsync(chapterEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхрнонный метод обновления данных таблицы ChapterEntity в базу данных
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="chapter">Модель Chapter</param>
    /// <returns>Индификатор обновленной записи</returns>
    public async Task Update(Guid id, Chapter chapter)
    {
        await DataBaseContext
            .Chapters.Where(f => f.ChapterId == id)
            .ExecuteUpdateAsync(s =>
                s
                //.SetProperty(s => s.ChapterName, chapter.ChapterName)
                .SetProperty(s => s.Readiness, chapter.Readiness)
                    .SetProperty(s => s.SpecificationId, chapter.SpecificationId)
                   // .SetProperty(s => s.CategoryDeviceId, chapter.CategoryDeviceId)
            );
    }

    /// <summary>
    /// Асинхрнонный метод удаления данных таблицы ChapterEntity в базу данных
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Индификатор удаленной записи</returns>
    public async Task Delete(Guid id)
    {
        await DataBaseContext.Chapters.Where(s => s.ChapterId == id).ExecuteDeleteAsync();
    }

    public async Task<List<Chapter>> GetFromChapSpecIds()
    {
        //List<ChapterEntity> listSpecId = new List<ChapterEntity>();
        //listSpecId = await DataBaseContext
        //    .Chapters.AsNoTracking()
        //    .Include(s => s.Specification)
        //    .OrderBy(s => s.Specification.Name).ToListAsync();
        //List<Chapter> chapterSpec = listSpecId.Select(s => 
        //    Chapter.Create(
        //        s.ChapterId, 
        //        s.SpecificationId, 
        //        s.Specification.Name)).ToList();
        return [];
    }

    public async Task<List<Chapter>> GetChapterDetail()
    {
        List<ChapterEntity> chapterEntities = new List<ChapterEntity>();
        chapterEntities = await DataBaseContext
            .Chapters.AsNoTracking()
            .Include(i => i.CategoryChapter).OrderBy(s=>s.CategoryChapterId)
            .ToListAsync();
        List<Chapter> chapterDetailList = chapterEntities
            .Select(s =>
                Chapter
                    .CreateDetail(
                        id: s.ChapterId,
                        chapterName: s.CategoryChapter.Name,
                        rd: s.Readiness,
                        costChap: s.CostChapter,
                        com: s.Comment,
                        catChapId: s.CategoryChapterId
                    )
                    .chp
            )
            .ToList();
        //List<Chapter> chaptersDetailList = ca
        return chapterDetailList;
    }

    public async Task<List<Chapter>> GetChapterDetail(Guid id)
    {
        List<ChapterEntity> chapterEntities = new List<ChapterEntity>();
        chapterEntities = await DataBaseContext
            .Chapters.AsNoTracking()
            .Where(f => f.SpecificationId == id).OrderBy(s => s.CategoryChapterId)
            .Include(i => i.CategoryChapter)
            .ToListAsync();
        List<Chapter> chapterDetailList = chapterEntities
            .Select(s =>
                Chapter
                    .CreateDetail(
                        id: s.ChapterId,
                        chapterName: s.CategoryChapter.Name,
                        rd: s.Readiness,
                        costChap: s.CostChapter,
                        com: s.Comment,
                        catChapId: s.CategoryChapterId
                    )
                    .chp
            )
            .ToList();
        //List<Chapter> chaptersDetailList = ca
        return chapterDetailList;
    }

    /// <summary>
    /// Асинхронный метод получения данных из БД таблицы ChapterEntity
    /// </summary>
    /// <returns></returns>
    public async Task<List<Chapter>> Get(Guid id = default)
    {
        List<ChapterEntity> chapterEntities = new List<ChapterEntity>();

        if (id == Guid.Empty)
        {
            chapterEntities = await DataBaseContext.Chapters.AsNoTracking().ToListAsync();
        }
        else
        {
            chapterEntities = await DataBaseContext
                .Chapters.Where(f => f.ChapterId == id)
                .AsNoTracking().OrderBy(s => s.CategoryChapterId)
                .ToListAsync();
        }

        List<Core.Models.Chapter> chapterList = chapterEntities
            .Select(s =>
                Core.Models.Chapter.Create(
                    id: s.ChapterId,
                  //  chapterName:s.ChapterName,
                    rd: s.Readiness,
                    costChap: s.CostChapter,
                    com: s.Comment,
                    specId: s.SpecificationId
                ).chp
            )
            .ToList();

        return chapterList;
    }

    public async Task<List<Chapter>> GetFromChapSpecId(Guid specId)
    {
        List<ChapterEntity> chapterEntities = new List<ChapterEntity>();
        chapterEntities = await DataBaseContext
            .Chapters.AsNoTracking()
            .Where(f => f.SpecificationId == specId).OrderBy(s => s.CategoryChapterId)
            .Include(i => i.SubChapters)
            .ToListAsync();
        List<Chapter> chapterDetailList = chapterEntities
            .Select(s =>
                Chapter
                    .Create(
                        chapterId: s.ChapterId,
                        categoryChapterId: s.CategoryChapterId,
                        readiness: s.Readiness,
                        costChapter: s.CostChapter,
                        comment: s.Comment,
                        subChapters: s.SubChapters.Select(ss=>SubChapter.Create(ss.SubChapId,ss.CategoryDeviceId, ss.ChapterId).sch).ToList()

                    )
            )
            .ToList();
        return chapterDetailList;
    }

    //public async Task AddWithResponsible(Chapter chapter)
    //{
    //    List<RespChapterEntity> respPersons = new List<RespChapterEntity>();
    //    foreach (var item in chapter.ResponsiblePersons)
    //    {
    //        respPersons.Add(
    //            new RespChapterEntity
    //            {
    //                EmpId = item.EmpId,
    //                ChapterId = chapter.ChapterId,
    //            }
    //        );
    //    }

    //    ChapterEntity chapEntity = new ChapterEntity
    //    {
    //        ChapterId = chapter.ChapterId,
    //        ChapterName = chapter.ChapterName,
    //        Comment = chapter.Comment,
    //        CostChapter = chapter.CostChapter,
    //        Readiness = chapter.Readiness,
    //        SpecificationId = chapter.SpecificationId,
    //        RespPersons = respPersons
    //    };

    //    await DataBaseContext.AddAsync(chapEntity);
    //    await DataBaseContext.SaveChangesAsync();
    //}
}
