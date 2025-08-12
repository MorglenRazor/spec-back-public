using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class AccountingDepService : IHandbookService<AccountingDep>
{
    private readonly IHandbookRepository<AccountingDep> _accountRepository;

    public AccountingDepService(IHandbookRepository<AccountingDep> accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<AccountingDep>> Get() => await _accountRepository.Get();

    public async Task Add(AccountingDep model) => await _accountRepository.Add(model);

    public async Task Update(int id, AccountingDep model) =>
        await _accountRepository.Update(id, model);

    public async Task Delete(int id) => await _accountRepository.Delete(id);
}
