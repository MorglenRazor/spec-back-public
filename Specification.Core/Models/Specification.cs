namespace Specification.Core.Models;

public class Specification
{

    private Specification(
        Guid id,
        List<Chapter> chapterIds
    )
    {
        SpecificationId = id;
        ChapterSpec = chapterIds;
    }

    private Specification(
        Guid id,
        string numWork,
        string numTask,
        string name,
        int totalUncoverPos,
        int readiness,
        int cusId
    )
    {
        SpecificationId = id;
        NumWork = numWork;
        NumTask = numTask;
        Name = name;
        TotalUncoverPos = totalUncoverPos;
        Readiness = readiness;
        CustomerSpecId = cusId;
    }

    private Specification(
        Guid id,
        string numWork,
        string numTask,
        string name,
        int totalUncoverPos,
        int readiness,
        int cusId,
        string customerName
    )
    {
        SpecificationId = id;
        NumWork = numWork;
        NumTask = numTask;
        Name = name;
        TotalUncoverPos = totalUncoverPos;
        Readiness = readiness;
        CustomerSpecId = cusId;
        CustomerName = customerName;
    }

  
    public static (Specification Spec, string ErrDesc) Create(
        Guid id,
        string numWork,
        string numTask,
        string name,
        int totalUncoverPos,
        int readiness,
        int cusId,
        string cusName
    )
    {
        Specification spec = new Specification(
            id,
            numWork,
            numTask,
            name,
            totalUncoverPos,
            readiness,
            cusId,
            cusName
        );
        return (spec, "Без ошибок");
    }

    public static (Specification Spec, string ErrDesc) Create(
        Guid id,
        List<Chapter> chapIds
    )
    {
        Specification spec = new Specification(
            id,
            chapIds
        );
        return (spec, "Без ошибок");
    }

    /// <summary>
    /// Метод для создания Модели Specification
    /// </summary>
    /// <param name="id">Индификатор</param>
    /// <param name="numWork">Номер проработки</param>
    /// <param name="numTask">Номер задания</param>
    /// <param name="name">Наименование</param>
    /// <param name="totalUncoverPos">Общее кол-во незакрытых позиций</param>
    /// <param name="readiness">Готовность объкта</param>
    /// <param name="cusId">Индификатор заказчика</param>
    /// <param name="chapters">Список разделов</param>
    /// <returns>Возврат: Словарь(Модель Specification, Модель Ошибок)</returns>
    public static (Specification Spec, string ErrDesc) Create(
        Guid id,
        string numWork,
        string numTask,
        string name,
        int totalUncoverPos,
        int readiness,
        int cusId
    )
    {
        Specification spec = new Specification(
            id,
            numWork,
            numTask,
            name,
            totalUncoverPos,
            readiness,
            cusId
        );
        return (spec, "Без ошибок");
    }



    public Guid SpecificationId { get; }
    public string NumWork { get; }
    public string NumTask { get; }
    public string Name { get; }
    public int TotalUncoverPos { get; } = 0;
    public int Readiness { get; }
    public int CustomerSpecId { get; }
    public string CustomerName { get; }
    public List<Guid> ChapterId { get; set; }
    public List<Chapter> ChapterSpec { get; }
}
