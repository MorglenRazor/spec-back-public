namespace Specification.Core.Models;

public class Customer
{
    private Customer(int id, string name, bool isVisible)
    {
        Id = id;
        Name = name;
        IsVisible = isVisible;

    }

    /// <summary>
    /// Метод для создания Модели Customer
    /// </summary>
    /// <param name="id">Индификатор</param>
    /// <param name="name">Наименование заказчика</param>
    /// <returns>Возврат: Словарь(Модель Customer, Модель Ошибок)</returns>
    public static (Customer customer, string err) Create(int id, string name, bool isVisible)
    {
        Customer customer = new Customer(id, name, isVisible);
        return (customer, "Без ошибок");
    }

    public int Id { get; }
    public string Name { get; } = string.Empty;
    public bool IsVisible { get; set; }
}
