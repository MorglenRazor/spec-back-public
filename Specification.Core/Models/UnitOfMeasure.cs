namespace Specification.Core.Models;

public class UnitOfMeasure
{
    private UnitOfMeasure(string name, int id, string shortName, bool isVisible)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
    }

    /// <summary>
    /// Создание модели UnitOfMeasure
    /// </summary>
    /// <param name="name">Наименование заказчика</param>
    /// <param name="shortName">Сокращенное наименование заказчика</param>
    /// <param name="id">индификатор</param>
    /// <returns>Возврат: Словарь(Модель UnitOfMeasure, Модель Ошибок)</returns>
    public static (UnitOfMeasure uom, string err) Create(string name, int id, string shortName, bool isVisible)
    {
        UnitOfMeasure unitOfMeasure = new UnitOfMeasure(name, id, shortName, isVisible);
        return (unitOfMeasure, "Без ошибок");
    }

    public int Id { get; }

    public string Name { get; } = string.Empty;
    public string ShortName { get; } = string.Empty;

    public bool IsVisible { get; set; }
}
