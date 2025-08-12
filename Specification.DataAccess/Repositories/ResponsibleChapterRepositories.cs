using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.Core.Models.Auth;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories
{
    public class ResponsibleChapterRepositories(SpecificationDataBaseContext dbContext)
        : BaseRepositories(dbContext), ITableRepository<ResponsibleCatChapter>, IRespCatChapterRepository
    {
        public async Task Add(ResponsibleCatChapter model)
        {
            RespChapterEntity entity = new RespChapterEntity
            {
                Id = model.RespId,
                CategoryChapterId = model.CategoryChapterId,
                EmpId = model.EmpId
            };

            await DataBaseContext.AddAsync(entity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.RespChapter.Where(f => f.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<ResponsibleCatChapter>> Get(Guid id)
        {
            List<RespChapterEntity> entities = await DataBaseContext
                .RespChapter.AsNoTracking().ToListAsync();
            List<ResponsibleCatChapter> result = entities.Select(s=> 
                ResponsibleCatChapter.Create(s.Id, s.EmpId, s.CategoryChapterId)).ToList();
            return result;
        }

        public async Task<List<ResponsibleCatChapter>> GetForCatId(Guid CatId)
        {
            List<RespChapterEntity> entities = await DataBaseContext
               .RespChapter.AsNoTracking().Include(i=>i.Responsible).Where(s => s.CategoryChapterId == CatId).ToListAsync();
            List<ResponsibleCatChapter> result = entities.Select(s =>
                ResponsibleCatChapter.Create(s.Id, s.EmpId, s.CategoryChapterId, 
                    userData: User.Create(
                        id: s.Responsible.Id,
                        userName: s.Responsible.UserName,
                        fullName: s.Responsible.FullName,
                        shortName:s.Responsible.ShortName,
                        phoneNumber: s.Responsible.PhoneNumber,
                        positionName: s.Responsible.PositionName,
                        depId: s.Responsible.DepartmentId
                        ))).ToList();
            return result;
        }

        public async Task Update(Guid id, ResponsibleCatChapter model)
        {
            await DataBaseContext.RespChapter.Where(f => f.Id == id)
                .ExecuteUpdateAsync( s=> 
                    s.SetProperty(s=>s.EmpId, model.EmpId)
                     .SetProperty(s=>s.CategoryChapterId, model.CategoryChapterId));
        }
    }
}
