using System.Security.Principal;

namespace Specification.DataAccess.Entities.Handbooks;

/// <summary>
/// Справочник единиц измерений
/// </summary>
public class UnitOfMeasureEntity
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование ед.изм
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Сокращенное название
    /// </summary>
    public string ShortName { get; set; } = String.Empty;

    public bool IsVisible { get; set; }

    public List<ConstructionDepartmentEntity> ConstructionDep { get; set; } = [];
    public List<TcDepartmentEntity> TechControlDep { get; set; } = [];

    public List<WarehouseDepartmentEntity> WarehouseDepGenUom { get; set; } = [];
    public List<WarehouseDepartmentEntity> WarehouseDepRemainUom { get; set; } = [];
    public List<AccountingDepartmentEntity> AccountingDep { get; set; } = [];
}
