using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Models.Auth;
using Specification.DataAccessAuth.Entities;
using Specification.DataAccessAuth.Repositories.Base;

namespace Specification.DataAccessAuth.Repositories
{
    public class DepartmentRepositories(AuthDataBaseContext dbContext)
        : BaseRepositories(dbContext),
            IDepartmentRepository
    {
        public async Task Add(Department model)
        {
            DepartmentEntity entity = new DepartmentEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.DepartmentName = model.DepartmentName;
                entity.DepShortName = model.DepShortName;
                await DataBaseContext.AddAsync(entity);
                await DataBaseContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.Departments.Where(f => f.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Department>> Get()
        {
            List<DepartmentEntity> department = new List<DepartmentEntity>();
            department = await DataBaseContext.Departments.AsNoTracking().ToListAsync();
            List<Department> dep = department
                .Select(s => Department.Create(s.Id, s.DepartmentName, s.DepShortName))
                .ToList();
            return dep;
        }

        public async Task<Department> Get(Guid id)
        {
            DepartmentEntity department = new DepartmentEntity();
            department = await DataBaseContext
                .Departments.AsNoTracking()
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            if (department != null)
            {
                Department dep = Department.Create(
                    department.Id,
                    department.DepartmentName,
                    department.DepShortName
                );
                return dep;
            }
            return null;
        }

        public async Task Update(Guid id, Department model)
        {
            await DataBaseContext
                .Departments.Where(f => f.Id == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(s => s.DepartmentName, model.DepartmentName)
                        .SetProperty(s => s.DepShortName, model.DepShortName)
                );
        }
    }
}
