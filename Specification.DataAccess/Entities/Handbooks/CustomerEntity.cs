namespace Specification.DataAccess.Entities.Handbooks;

/// <summary>
/// Заказчик
/// </summary>
public class CustomerEntity
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование заказчика
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public bool IsVisible { get; set; }
    public List<SpecificationEntity>? Specification { get; set; }
}
