using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories
{
    public class CategoryChapterRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<CategoryChapter>, ICategoryChapterRepository
    {
        public async Task Add(CategoryChapter model)
        {
            CategoryChapterHandbookEntity entity = new CategoryChapterHandbookEntity
            {
                CategoryChapterId = model.CategoryChapterId,
                Name = model.Name
            };
            await DataBaseContext.AddAsync(entity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task AddWithResponsible(CategoryChapter categoryChapter)
        {
            List<RespChapterEntity> respPersons = new List<RespChapterEntity>();
            foreach (var item in categoryChapter.ResponsiblePersons)
            {
                respPersons.Add(
                    new RespChapterEntity
                    {
                        EmpId = item.EmpId,
                        CategoryChapterId = categoryChapter.CategoryChapterId,
                    }
                );
            }

            CategoryChapterHandbookEntity entity = new CategoryChapterHandbookEntity
            {
                CategoryChapterId = categoryChapter.CategoryChapterId,
                Name = categoryChapter.Name,
                RespPersons = respPersons
            };

            await DataBaseContext.AddAsync(entity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.CategoryChapterHandbook.Where(f => f.CategoryChapterId == id).ExecuteDeleteAsync();
        }

        public async Task<List<CategoryChapter>> Get(Guid id)
        {
            List<CategoryChapterHandbookEntity> entities = await DataBaseContext
                .CategoryChapterHandbook
                .AsNoTracking()
                .ToListAsync();
            var result = entities.Select(s=>CategoryChapter.Create(s.CategoryChapterId,s.Name)).ToList();
            return result;
        }

        public async Task Update(Guid id, CategoryChapter model)
        {
            await DataBaseContext
                .CategoryChapterHandbook
                .Where(f => f.CategoryChapterId == id)
                .ExecuteUpdateAsync(e => e.SetProperty(s => s.Name, model.Name));
        }
    }
}
