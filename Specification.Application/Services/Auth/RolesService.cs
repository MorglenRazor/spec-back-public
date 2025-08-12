using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models.Auth;

namespace Specification.Application.Services.Auth
{
    public class RolesService : IHandbookService<Roles>
    {
        private readonly IHandbookRepository<Roles> _rolesRepos;

        public RolesService(IHandbookRepository<Roles> rolesRepos)
        {
            _rolesRepos = rolesRepos;
        }

        public async Task Add(Roles model) => await _rolesRepos.Add(model);

        public async Task Delete(int id) => await _rolesRepos.Delete(id);

        public async Task<List<Roles>> Get() => await _rolesRepos.Get();

        public Task Update(int id, Roles model)
        {
            throw new NotImplementedException();
        }
    }
}
