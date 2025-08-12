namespace Specification.DataAccess.Entities.Handbooks;

/// <summary>
/// Поставщик/подрядчик
/// </summary>
public class ContractorEntity
{
    public int ContractorId { get; set; }

    /// <summary>
    /// Наименование подрядчика
    /// </summary>
    public string ContractorName { get; set; } = string.Empty;

    /// <summary>
    /// Номер ИНН
    /// </summary>
    public string Inn { get; set; } = string.Empty;

    public bool IsVisible { get; set; }

    /// <summary>
    ///
    /// </summary>
    public List<TmsDepartmentEntity> TechMaterialDep { get; set; }
}
