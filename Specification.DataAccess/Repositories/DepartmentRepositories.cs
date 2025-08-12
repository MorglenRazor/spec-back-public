using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class DepartmentRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<Department>, IDepartmentRepository
{
    public async Task<List<Department>> Get()
    {
        List<DepartmentEntity> depEntity = await DataBaseContext
            .DepartmentContext.AsNoTracking()
            .ToListAsync();
        List<Department> departments = depEntity
            .Select(s => Department.Create(id: s.Id, name: s.Name, shortName: s.ShortName).dep)
            .ToList();
        return departments;
    }

    public async Task<List<Department>> Get(Guid id)
    {
        if (id == Guid.Empty)
        {
            List<DepartmentEntity> depEntity = await DataBaseContext
            .DepartmentContext.AsNoTracking()
            .ToListAsync();
            List<Department> departments = depEntity
                .Select(s => Department.Create(id: s.Id, name: s.Name, shortName: s.ShortName).dep)
                .ToList();
            return departments;
        }
        else
        {
            List<DepartmentEntity> depEntity = await DataBaseContext
            .DepartmentContext.AsNoTracking().Where(f => f.Id == id)
            .ToListAsync();
            List<Department> departments = depEntity
                .Select(s => Department.Create(id: s.Id, name: s.Name, shortName: s.ShortName).dep)
                .ToList();
            return departments;
        }
        
    }



    public async Task Add(Department model)
    {
        DepartmentEntity departmentEntity = new DepartmentEntity
        {
            Id = model.Id,
            Name = model.Name,
            ShortName = model.ShortName
        };
        await DataBaseContext.AddAsync(departmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, Department model)
    {
        await DataBaseContext
            .DepartmentContext.Where(f => f.Id == id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.Name, model.Name));
    }

    public async Task Delete(Guid id) =>
        await DataBaseContext.DepartmentContext.Where(f => f.Id == id).ExecuteDeleteAsync();

    public async Task<Guid> Get(string ShortName)
    {
        List<DepartmentEntity> depEntity = await DataBaseContext
            .DepartmentContext.AsNoTracking().Where(f => f.ShortName.Equals(ShortName))
            .ToListAsync();
        var dep = depEntity.FirstOrDefault();
        if(dep != null)
            return dep.Id;

        return Guid.Empty;
        
    }
}
