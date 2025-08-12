using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Entities;

/// <summary>
/// Конструкторский отдел.
/// Сущность описывает поля которые заполняет отдел
/// </summary>
public class ConstructionDepartmentEntity
{
    public int ConstructionDepId { get; set; }

    

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; set; } = String.Empty;

    #region Единица измерения

    public int UnitId { get; set; }
    public UnitOfMeasureEntity? Uom { get; set; }

    #endregion


    #region Ответственный

    public Guid? EmployerResponsibleId { get; set; }
    public EmployerEntity? EmployerData { get; set; }

    #endregion

    /// <summary>
    /// Внещний ключ для связи с таблицей DeviceChapterEntity
    /// </summary>
    public Guid DeviceChapterId { get; set; }
    public DevicesChapterEntity? DeviceChapter { get; set; }
}
