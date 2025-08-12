using Microsoft.EntityFrameworkCore;
using Specification.DataAccess.Configurations;
using Specification.DataAccess.Configurations.Auth;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess;

public class SpecificationDataBaseContext(DbContextOptions<SpecificationDataBaseContext> options)
    : DbContext(options)
{
    /// <summary>
    /// Контекст таблицы Спецификации
    /// </summary>
    public DbSet<SpecificationEntity> Specifications { get; set; }

    /// <summary>
    /// Контекс таблицы Раздела
    /// </summary>
    public DbSet<ChapterEntity> Chapters { get; set; }

    /// <summary>
    /// Контекс таблицы Раздела
    /// </summary>
    public DbSet<DevicesChapterEntity> DevicesChapter { get; set; }

    /// <summary>
    /// Контекс справочника Категория девайсов
    /// </summary>
    public DbSet<CategoryDeviceEntity> CategoryDevices { get; set; }

    /// <summary>
    /// Контекс справочника устройств
    /// </summary>
    public DbSet<DeviceHandbookEntity> Devices { get; set; }

    /// <summary>
    /// Контекст таблицы Конструкторской части
    /// </summary>
    public DbSet<ConstructionDepartmentEntity> ConstructionDepartment { get; set; }

    /// <summary>
    /// Контекст таблицы ОТМС части
    /// </summary>
    public DbSet<TmsDepartmentEntity> TmsDepartment { get; set; }

    /// <summary>
    /// Контекст таблицы ОТК части
    /// </summary>
    public DbSet<TcDepartmentEntity> TcDepartment { get; set; }

    /// <summary>
    /// Контекст таблицы части СКЛАДА
    /// </summary>
    public DbSet<WarehouseDepartmentEntity> WarehouseDepartment { get; set; }

    /// <summary>
    /// Контекст таблицы части Бухгалтерии
    /// </summary>
    public DbSet<AccountingDepartmentEntity> AccountingDepartment { get; set; }


    /// <summary>
    /// Контекс справочника ед.измерений
    /// </summary>
    public DbSet<UnitOfMeasureEntity> UnitOfMeasure { get; set; }

    /// <summary>
    /// Контекс справочника подрядчика
    /// </summary>
    /// <returns></returns>
    public DbSet<ContractorEntity> Contractor { get; set; }

    /// <summary>
    /// Контекс справочника заказчика
    /// </summary>
    public DbSet<CustomerEntity> Customer { get; set; }

    //public DbSet<SubCategoryDeviceEntity> SubCategorysDevice { get; set; }

    /// <summary>
    /// Контекс справочника отделов
    /// </summary>
    public DbSet<DepartmentEntity> DepartmentContext { get; set; }

   // public DbSet<ResponsiblePersonsSpecEntity> ResponsibleSpec { get; set; }

    public DbSet<SubChapterEntity> SubChapters { get; set; }

    public DbSet<RoleEntity> RolesTable { get; set; }
    public DbSet<EmployerEntity> Users { get; set; }
    public DbSet<EmployerRoleEntity> UserRoles { get; set; }

    public DbSet<StatusDeviceHandbookEntity> StatusHandbook { get; set; }

    public DbSet<RespChapterEntity> RespChapter { get; set; }

    public DbSet<CategoryChapterHandbookEntity> CategoryChapterHandbook { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpecificationConfiguration());
        modelBuilder.ApplyConfiguration(new ChapterConfiguration());
        modelBuilder.ApplyConfiguration(new ChapterDevicesConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryDeviceConfiguration());
        modelBuilder.ApplyConfiguration(new AccountingDepConfiguration());
        modelBuilder.ApplyConfiguration(new ContractorConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ConstructionDepConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceHandbookConfiguration());
        modelBuilder.ApplyConfiguration(new TcDepConfiguration());
        modelBuilder.ApplyConfiguration(new TmsDepConfiguration());
        modelBuilder.ApplyConfiguration(new WarehouseDepConfiguration());
        modelBuilder.ApplyConfiguration(new UnitOfMeasureConfiguration());
       // modelBuilder.ApplyConfiguration(new ResponsiblePersonsSpecConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new SubChapterConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployerRoleEntityConfiguration());
        //modelBuilder.ApplyConfiguration(new SubCategoryDeviceConfiguration());
        modelBuilder.ApplyConfiguration(new StatusHandbookConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryChapterHandbookConfiguration());
        modelBuilder.ApplyConfiguration(new RespChapterConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
