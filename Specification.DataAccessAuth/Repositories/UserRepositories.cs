using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Models.Auth;
using Specification.DataAccessAuth.Entities;
using Specification.DataAccessAuth.Repositories.Base;

namespace Specification.DataAccessAuth.Repositories
{
    public class UserRepositories(AuthDataBaseContext dbContext)
        : BaseRepositories(dbContext),
            IUserRepository
    {
        public async Task<User> GetUser(string userName)
        {
            UserEntity user = new UserEntity();
            if (!string.IsNullOrEmpty(userName))
            {
                user = await DataBaseContext
                    .Users.AsNoTracking()
                    .Include(f => f.Department)
                    .Where(f => f.UserName == userName)
                    .FirstOrDefaultAsync();
            }
            if (user != null)
            {
                User userModel = User.Create(
                    user.Id,
                    user.UserName,
                    user.Password,
                    user.FullName,
                    user.ShortName,
                    user.PhoneNumber,
                    user.PositionName,
                    user.Department.DepartmentName,
                    []
                );
                return userModel;
            }
            return null;
        }

        public async Task<User> GetUser(Guid empId, Guid depId)
        {
            UserEntity user = new UserEntity();
            user = await DataBaseContext
                .Users.AsNoTracking()
                .Include(u => u.Roles)
                .Include(f => f.Department)
                .Where(f => f.Id == empId && f.DepartmentId == depId)
                .FirstOrDefaultAsync();
            // var ro = user.Roles.ToArray();
            //string combinedString = string.Join(",", user.Roles.Select(s=>s.NameRole));
            //string roleNames = "[" + combinedString + "]";
            //Console.WriteLine(combinedString);
            User userModel = User.Create(
                user.Id,
                user.UserName,
                user.Password,
                user.FullName,
                user.ShortName,
                user.PhoneNumber,
                user.PositionName,
                user.Department.DepartmentName,
                user.Roles.Select(s => s.NameRole).ToList()
            );
            return userModel;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            UserEntity user = new UserEntity();
            user = await DataBaseContext
                .Users.AsNoTracking()
                .Include(f => f.Department)
                .Where(f => f.Id == userId)
                .FirstOrDefaultAsync();
            User userModel = User.CreateWtPassword(
                user.UserName,
                user.FullName,
                user.PhoneNumber,
                user.Department?.DepartmentName,
                user.PositionName
            );
            return userModel;
        }

        public async Task<List<User>> GetUsers()
        {
            List<UserEntity> user = new List<UserEntity>();
            user = await DataBaseContext
                .Users.AsNoTracking()
                .Include(f => f.Department)
                .ToListAsync();
            List<User> users = user.Select(s =>
                    User.Create(
                        s.Id,
                        s.UserName,
                        s.FullName,
                        s.ShortName,
                        s.PhoneNumber,
                        s.PositionName,
                        s.Department.Id
                    )
                )
                .ToList();
            return users;
        }

        public async Task RegistrationUser(User model)
        {
            UserEntity newUser = new UserEntity();
            if (model != null)
            {
                newUser.Id = model.Id;
                newUser.UserName = model.UserName;
                newUser.Password = model.Password;
                newUser.FullName = model.FullName;
                newUser.ShortName = model.ShortName;
                newUser.PhoneNumber = model.PhoneNumber;
                newUser.PositionName = model.PositionName;
                newUser.DepartmentId = model.DepartmentId;

                await DataBaseContext.AddAsync(newUser);
                await DataBaseContext.SaveChangesAsync();
            }
        }

        public async Task UpdateInfo(Guid id, User model)
        {
            await DataBaseContext
                .Users.Where(f => f.Id == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(s => s.UserName, model.UserName)
                        .SetProperty(s => s.FullName, model.FullName)
                        .SetProperty(s => s.ShortName, model.ShortName)
                        .SetProperty(s => s.PhoneNumber, model.PhoneNumber)
                        .SetProperty(s => s.PositionName, model.PositionName)
                        .SetProperty(s => s.DepartmentId, model.DepartmentId)
                );
        }

        public async Task UpdatePassword(Guid id, User model)
        {
            await DataBaseContext
                .Users.Where(f => f.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(s => s.Password, model.Password));
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.Users.Where(f => f.Id == id).ExecuteDeleteAsync();
        }

        public async Task AddRole(Guid Id, int RoleId)
        {
            UserRoleEntity userRoleEntity = new UserRoleEntity { RoleId = RoleId, UserId = Id };
            await DataBaseContext.UserRoles.AddAsync(userRoleEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task<List<RolesPermissions>> GetUserPermissions(Guid userId)
        {
            var roles = await DataBaseContext
                .Users.AsNoTracking()
                .Include(u => u.Roles)
                .Where(u => u.Id == userId)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles.SelectMany(r => r).Select(p => new RolesPermissions(p.NameRole)).ToList();
        }
    }
}
