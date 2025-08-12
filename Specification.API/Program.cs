using Microsoft.EntityFrameworkCore;
using Specification.API;
using Specification.API.Hubs;
using Specification.Application.Interfaces.Auth;
using Specification.Application.Services;
using Specification.Application.Services.Auth;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Abstractions.Service;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models;
using Specification.Core.Models.Auth;
using Specification.DataAccess;
using Specification.DataAccess.Repositories;
using Specification.DataAccess.Repositories.Auth;
using Specification.DataAccessAuth;

using Specification.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        builder.Services.AddStackExchangeRedisCache(option =>
        {
            var connection = configuration.GetConnectionString("Redis");
            option.Configuration = connection;
        });

#if RELEASE

     

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSignalR();

        builder.Services.AddDbContext<SpecificationDataBaseContext>(opt =>
        {
            opt.UseNpgsql(
                configuration.GetConnectionString("SpecificationDataBaseContextPostgre")

            );
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        builder.Services.Configure<AuthorizationOptions>(
            configuration.GetSection(nameof(AuthorizationOptions))
        );

#else


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSignalR();

        builder.Services.AddDbContext<SpecificationDataBaseContext>(opt =>
        {
            opt.UseMySql(
               configuration.GetConnectionString(nameof(SpecificationDataBaseContext)),
               new MySqlServerVersion(new Version(5, 5, 30))
            );
        });
        builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        builder.Services.Configure<AuthorizationOptions>(
            configuration.GetSection(nameof(AuthorizationOptions))
        );

#endif





        builder.Services.AddApiAuthentication(configuration);

        builder.Services.AddScoped<
            ITableService<Specification.Core.Models.Specification>,
            SpecificationService
        >();
        builder.Services.AddScoped<
            ITableRepository<Specification.Core.Models.Specification>,
            SpecificationRepositories
        >();
        builder.Services.AddScoped<ISpecificationService, SpecificationService>();
        builder.Services.AddScoped<ISpecificationRepository, SpecificationRepositories>();

        builder.Services.AddScoped<ITableService<Chapter>, ChapterService>();
        builder.Services.AddScoped<ITableRepository<Chapter>, ChapterRepositories>();

        builder.Services.AddScoped<IChapterService, ChapterService>();
        builder.Services.AddScoped<IChapterRepository, ChapterRepositories>();

        builder.Services.AddScoped<ITableService<SubChapter>, SubChapterService>();
        builder.Services.AddScoped<ITableRepository<SubChapter>, SubChapterRepositories>();

        builder.Services.AddScoped<ISubChapterService, SubChapterService>();
        builder.Services.AddScoped<ISubChapterRepository, SubChapterRepositories>();

        builder.Services.AddScoped<ITableService<DevicesChapter>, ChapterDeviceService>();
        builder.Services.AddScoped<ITableRepository<DevicesChapter>, ChapterDevicesRepositories>();

        builder.Services.AddScoped<IChapterDeviceService, ChapterDeviceService>();
        builder.Services.AddScoped<IChapterDeviceRepository, ChapterDevicesRepositories>();

        builder.Services.AddScoped<ITableService<CategoryDevice>, CategoryDeviceService>();
        builder.Services.AddScoped<ITableRepository<CategoryDevice>, CategoryDeviceRepositories>();

        builder.Services.AddScoped<ITableService<CategoryChapter>, CategoryChapterService>();
        builder.Services.AddScoped<ITableRepository<CategoryChapter>, CategoryChapterRepositories>();

        builder.Services.AddScoped<ITableService<ResponsibleCatChapter>, RespChapterService>();
        builder.Services.AddScoped<IRespCatChapterService, RespChapterService>();
        builder.Services.AddScoped<ITableRepository<ResponsibleCatChapter>, ResponsibleChapterRepositories>();
        builder.Services.AddScoped<IRespCatChapterRepository, ResponsibleChapterRepositories>();

        //builder.Services.AddScoped<ITableService<SubCategoryDevice>, SubCategoryDeviceService>();
        //builder.Services.AddScoped<ITableRepository<SubCategoryDevice>, SubCategoryDeviceRepositories>();

        builder.Services.AddScoped<ITableService<Device>, DeviceService>();
        builder.Services.AddScoped<ITableRepository<Device>, DeviceRepositories>();
        builder.Services.AddScoped<IDeviceService, DeviceService>();
        builder.Services.AddScoped<IDeviceRepository, DeviceRepositories>();

        builder.Services.AddScoped<IHandbookService<ConstructionDep>, ConstructionDepService>();
        builder.Services.AddScoped<IHandbookRepository<ConstructionDep>, ConstructionDepRepositories>();

        builder.Services.AddScoped<IHandbookService<TmsDep>, TmsDepService>();
        builder.Services.AddScoped<ITmsService, TmsDepService>();
        builder.Services.AddScoped<IHandbookRepository<TmsDep>, TmsDepRepositories>();
        builder.Services.AddScoped<ITmsRepository, TmsDepRepositories>();

        builder.Services.AddScoped<IHandbookService<TcDep>, TcDepService>();
        builder.Services.AddScoped<IHandbookRepository<TcDep>, TcDepRepositories>();

        builder.Services.AddScoped<IHandbookService<WarehouseDep>, WarehouseDepService>();
        builder.Services.AddScoped<IHandbookRepository<WarehouseDep>, WarehouseDepRepositories>();

        builder.Services.AddScoped<IHandbookService<AccountingDep>, AccountingDepService>();
        builder.Services.AddScoped<IHandbookRepository<AccountingDep>, AccountingDepRepositories>();

        builder.Services.AddScoped<IHandbookService<Contractor>, ContractorService>();
        builder.Services.AddScoped<IHandbookRepository<Contractor>, ContractorRepositories>();

        builder.Services.AddScoped<IHandbookService<Customer>, CustomerService>();
        builder.Services.AddScoped<IHandbookRepository<Customer>, CustomerRepositories>();

        builder.Services.AddScoped<IHandbookService<UnitOfMeasure>, UnitOfMeasureService>();
        builder.Services.AddScoped<IUomService, UnitOfMeasureService>();
        builder.Services.AddScoped<IHandbookRepository<UnitOfMeasure>, UnitOfMeasureRepositories>();
        builder.Services.AddScoped<IUomRepository, UnitOfMeasureRepositories>();

        builder.Services.AddScoped<IHandbookService<Roles>, RolesService>();
        builder.Services.AddScoped<IHandbookRepository<Roles>, RoleRepositories>();

        builder.Services.AddScoped<
            ITableService<Specification.Core.Models.Department>, DepartmentService>();
        builder.Services.AddScoped<
            ITableRepository<Specification.Core.Models.Department>, DepartmentRepositories>();

        //builder.Services.AddScoped<ITableService<ResponsibleSpec>, ResponsibleSpecService>();
        //builder.Services.AddScoped<IResponsibleSpecService, ResponsibleSpecService>();

        //builder.Services.AddScoped<ITableRepository<ResponsibleSpec>, ResponsiblePersonsSpecRepositories>();
        //builder.Services.AddScoped<IResponsibleSpecRepository, ResponsiblePersonsSpecRepositories>();

        builder.Services.AddScoped<IJwtProvider, JwtProvider>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepositories>();

        builder.Services.AddScoped<IHandbookService<Roles>, RolesService>();
        builder.Services.AddScoped<IHandbookRepository<Roles>, RoleRepositories>();

        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositories>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();

        builder.Services.AddScoped<ITableService<StatusDeviceHandbook>, StatusDeviceHandbookService>();
        builder.Services.AddScoped<ITableRepository<StatusDeviceHandbook>, StatusDeviceHandbookRepositories>();

        builder.Services.AddScoped<IStatusDeviceHandbookService, StatusDeviceHandbookService>();
        builder.Services.AddScoped<IStatusDeviceHandbookRepository, StatusDeviceHandbookRepositories>();

        //builder.Services.AddScoped<IResponsibleSpecService, CheckAccess>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.+-+
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //app.UseCors(builder => builder.AllowAnyOrigin());

        app.UseHttpsRedirection();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<NotificationHub>("/ntfHub");
        app.MapHub<DefaultHub>("/defaultHub");

        


        app.Run();
    }
}

#if RELEASE

#else
#endif
