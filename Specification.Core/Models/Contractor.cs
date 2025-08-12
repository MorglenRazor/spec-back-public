namespace Specification.Core.Models;

public class Contractor
{
    private Contractor(string contractorName, string inn, int id, bool isVisible)
    {
        ContractorId = id;
        ContractorName = contractorName;
        Inn = inn;
        IsVisible = isVisible;

    }

    /// <summary>
    /// Метод для создания Модели Contractor
    /// </summary>
    /// <param name="contractorName">Наименование подрядчика</param>
    /// <param name="inn">Номер ИНН</param>
    /// <param name="id">Индификатор</param>
    /// <returns>Возврат: Словарь(Модель Contractor, Модель Ошибок)</returns>
    public static (Contractor contractor, string err) Create(
        string contractorName,
        string inn,
        int id,
        bool isVisible
    )
    {
        Contractor contractor = new Contractor(contractorName, inn, id, isVisible);
        return (contractor, "Без ошибок");
    }

    public int ContractorId { get; }

    /// <summary>
    /// Наименование подрядчика
    /// </summary>
    public string ContractorName { get; } = string.Empty;

    /// <summary>
    /// Номер ИНН
    /// </summary>
    public string Inn { get; } = string.Empty;

    public bool IsVisible { get; set; }
}
