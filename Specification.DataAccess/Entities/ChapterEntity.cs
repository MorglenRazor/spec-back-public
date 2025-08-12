using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Сущность раздела
/// </summary>
public class ChapterEntity
{
    public Guid ChapterId { get; set; }

    /// <summary>
    /// Готовность раздела
    /// </summary>
    public float Readiness { get; set; } = 0.0f;

    /// <summary>
    /// Итоговая стоимсость разедла
    /// </summary>
    public decimal CostChapter { get; set; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Внешний ключ для связи с SpecificationEntity
    /// </summary>
    public Guid SpecificationId { get; set; }
    public SpecificationEntity? Specification { get; set; }

    /// <summary>
    /// Список подразделов
    /// </summary>
    public List<SubChapterEntity> SubChapters { get; set; } = [];



    ///// <summary>
    ///// Связь 1 к М с таблицей
    ///// </summary>
    //public List<DevicesChapterEntity> DevicesList { get; set; } = [];

    public Guid CategoryChapterId { get; set; }
    public CategoryChapterHandbookEntity? CategoryChapter { get; set; }

}
