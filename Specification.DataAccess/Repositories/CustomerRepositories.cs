using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class CustomerRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<Customer>
{
    public async Task<List<Customer>> Get()
    {
        List<CustomerEntity> customerEntities = await DataBaseContext
            .Customer.AsNoTracking()
            .Where(f=>f.IsVisible)
            .ToListAsync();
        List<Customer> customers = customerEntities
            .Select(s => Customer.Create(id: s.Id, name: s.Name, isVisible: s.IsVisible).customer)
            .ToList();
        return customers;
    }

    public async Task Add(Customer model)
    {
        CustomerEntity customerEntity = new CustomerEntity { Name = model.Name, IsVisible = true };
        await DataBaseContext.AddAsync(customerEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    public async Task Update(int id, Customer model)
    {
        await DataBaseContext
            .Customer.Where(f => f.Id == id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.Name, model.Name));
    }

    public async Task Delete(int id) =>
        await DataBaseContext.Customer.Where(f => f.Id == id).ExecuteDeleteAsync();
}
