using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Models.Auth;
using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Repositories.Base;
using Specification.Infrastructure;

namespace Specification.DataAccess.Repositories.Auth
{
    public class UserRepositories(SpecificationDataBaseContext dbContext) : BaseRepositories(dbContext), IUserRepository
    {

        public async Task<bool> CheckAdmin(Guid userId)
        {
            EmployerEntity employers = new EmployerEntity();
            employers = await DataBaseContext
                .Users.AsNoTracking()
                .Where(f => f.Id == userId).FirstOrDefaultAsync();
            return employers.IsAdmin;
        }

        public async Task AddRole(Guid Id, int RoleId)
        {
            EmployerRoleEntity userRoleEntity = new EmployerRoleEntity { RoleId = RoleId, EmployerId = Id };
            await DataBaseContext.UserRoles.AddAsync(userRoleEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id) => await DataBaseContext.Users.Where(f => f.Id == id).ExecuteDeleteAsync();
        public async Task<User> GetUser(string userName)
        {
            EmployerEntity employer = new EmployerEntity();
            employer = await DataBaseContext.Users
                .AsNoTracking()
                .Include(i => i.Department)
                .Where(f => f.Equals(userName))
                .FirstOrDefaultAsync();
            User userModel = User.Create(
                   employer.Id,
                   employer.UserName,
                   employer.Password,
                   employer.FullName,
                   employer.ShortName,
                   employer.PhoneNumber,
                   employer.PositionName,
                   employer.Department.Name,
                   employer.Department.Id,
                   []
               );
            return userModel;
        }

        public async Task<User> GetUser(Guid empId, Guid depId)
        {
            EmployerEntity employer = new EmployerEntity();
            employer = await DataBaseContext
               .Users.AsNoTracking()
               .Include(u => u.Roles)
               .Include(f => f.Department)
               .Where(f => f.Id == empId && f.DepartmentId == depId)
               .FirstOrDefaultAsync();
            User userModel = User.Create(
                employer.Id,
                employer.UserName,
                employer.Password,
                employer.FullName,
                employer.ShortName,
                employer.PhoneNumber,
                employer.PositionName,
                employer.Department.Name,
                employer.Department.Id,
                employer.Roles.Select(s => s.NameRole).ToList()
            );
            return userModel;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            EmployerEntity employer = new EmployerEntity();
            employer = await DataBaseContext
               .Users.AsNoTracking()
               .Include(f => f.Department)
               .Where(f => f.Id == userId)
               .FirstOrDefaultAsync();
            User userModel = User.CreateWtPassword(
                employer.UserName,
                employer.FullName,
                employer.ShortName,
                employer.PhoneNumber,
                employer.Department.Name,
                employer.PositionName,
                employer.DepartmentId
            );
            return userModel;
        }

        public async Task<List<User>> GetUsers()
        {
            List<EmployerEntity> employers = new List<EmployerEntity>();  
            employers = await DataBaseContext
                .Users.AsNoTracking()
                .Include(f => f.Department)
                .ToListAsync();
            List<User> users = employers.Select(s =>
                    User.Create(
                        s.Id,
                        s.UserName,
                        s.FullName,
                        s.ShortName,
                        s.PhoneNumber,
                        s.PositionName,
                        s.Department.Id)).ToList();
            return users;
        }

        public async Task<List<User>> GetUsers(Guid depId)
        {
            List<EmployerEntity> employers = new List<EmployerEntity>();
            employers = await DataBaseContext
                .Users.AsNoTracking()
                .Include(f => f.Department)
                .Where(f=>f.DepartmentId == depId)
                .ToListAsync();
            List<User> users = employers.Select(s =>
                    User.Create(
                        s.Id,
                        s.UserName,
                        s.FullName,
                        s.ShortName,
                        s.PhoneNumber,
                        s.PositionName,
                        s.Department.Id)).ToList();
            return users;
        }

        public async Task<List<User>> GetFullInfoUsers()
        {
            List<EmployerEntity> employers = new List<EmployerEntity>();
            employers = await DataBaseContext
                .Users.AsNoTracking()
                .Include(f => f.Department)
                .ToListAsync();
            List<User> users = employers.Select(s =>
                    User.Create(
                        s.Id ,
                        s.UserName,
                        s.Password,
                        s.FullName,
                        s.ShortName,
                        s.PhoneNumber,
                        s.PositionName,
                        s.IsAdmin,
                        s.IsActual,
                        s.Department.Id)).ToList();
            return users;
        }

        public async Task RegistrationUser(User model)
        {
            EmployerEntity newUser = new EmployerEntity();
            if (model != null)
            {
                newUser.Id = model.Id;
                newUser.UserName = model.UserName;
                newUser.Password = PasswordHasher.GenerateStatic(model.Password);
                newUser.FullName = model.FullName;
                newUser.ShortName = model.ShortName;
                newUser.PhoneNumber = model.PhoneNumber;
                newUser.PositionName = model.PositionName;
                newUser.DepartmentId = model.DepartmentId;
                newUser.IsActual = model.IsActual;
                newUser.IsAdmin = model.IsAdmin;
               
                await DataBaseContext.AddAsync(newUser);
                await DataBaseContext.SaveChangesAsync();
                await AddRole(model.Id, 8);
            }
        }

        public async Task UpdateUser(Guid empId, User user)
        {
            await DataBaseContext
                .Users.Where(s => s.Id == empId)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(s => s.UserName, user.UserName)
                        .SetProperty(s => s.Password, PasswordHasher.GenerateStatic(user.Password))
                        .SetProperty(s => s.FullName, user.FullName)
                        .SetProperty(s => s.ShortName, user.ShortName)
                        .SetProperty(s => s.PhoneNumber, user.PhoneNumber)
                        .SetProperty(s => s.PositionName, user.PositionName)
                        .SetProperty(s => s.IsAdmin, user.IsAdmin)
                        .SetProperty(s => s.IsActual, user.IsActual)
                );
        }

      

        public async Task UpdatePassword(Guid id, User model)
        {
            await DataBaseContext
                .Users.Where(f => f.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(s => s.Password, PasswordHasher.GenerateStatic(model.Password)));
        }
    }
}
