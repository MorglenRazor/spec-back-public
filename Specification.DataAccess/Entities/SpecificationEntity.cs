using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Сущность спецификации.
/// </summary>
public class SpecificationEntity
{
    public Guid SpecId { get; set; }

    /// <summary>
    /// Номер проработки
    /// </summary>
    public String NumWork { get; set; } = String.Empty;

    /// <summary>
    /// Номер задания
    /// </summary>
    public String NumTask { get; set; } = String.Empty;

    /// <summary>
    /// Наименование
    /// </summary>
    public String Name { get; set; } = String.Empty;

    /// <summary>
    /// Общее кол-во незакрытых позиций
    /// </summary>
    public int TotalUncoverPos { get; set; } = 0;

    /// <summary>
    /// Готовность объкта
    /// </summary>
    public float Readiness { get; set; }

    public DateTime DateCreate { get; set; } = default;

   

    #region Свзязь с customer

    /// <summary>
    /// Внешний ключ
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Свзявь между таблицей Specification и справочником Customer
    /// </summary>
    public CustomerEntity? Customer { get; set; }

    #endregion

    /// <summary>
    /// Связь 1 к М с таблицей ChapterEntity
    /// </summary>
    public List<ChapterEntity> Chapters { get; set; } = [];
}
