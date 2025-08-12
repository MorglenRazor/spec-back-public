using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models.Auth;
using Specification.DataAccessAuth.Entities;
using Specification.DataAccessAuth.Repositories.Base;

namespace Specification.DataAccessAuth.Repositories
{
    public class RoleRepositories(AuthDataBaseContext dbContext)
        : BaseRepositories(dbContext),
            IHandbookRepository<Roles>
    {
        public async Task Add(Roles model)
        {
            int countRecordRoles = await DataBaseContext.RolesTable.CountAsync();
            RoleEntity roleEntity = new RoleEntity
            {
                Id = countRecordRoles + 1,
                NameRole = model.NameRole,
            };
            await DataBaseContext.AddAsync(roleEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id) =>
            await DataBaseContext.RolesTable.Where(f => f.Id == id).ExecuteDeleteAsync();

        public async Task<List<Roles>> Get()
        {
            List<RoleEntity> roleEntities = await DataBaseContext
                .RolesTable.AsNoTracking()
                .ToListAsync();
            List<Roles> roles = roleEntities
                .Select(s => Roles.Create(id: s.Id, nameRole: s.NameRole))
                .ToList();
            return roles;
        }

        public Task Update(int id, Roles model)
        {
            throw new NotImplementedException();
        }
    }
}
