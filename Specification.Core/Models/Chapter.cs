namespace Specification.Core.Models;

public class Chapter
{

    private Chapter(Guid id, Guid catChapId)
    {
        ChapterId = id;
        CategoryChapterId = catChapId;
    }

    public static Chapter Create(Guid chapterId,Guid categoryChapterId)
    {
        Chapter chapter = new Chapter(chapterId, categoryChapterId);
        return chapter;
    }

    private Chapter(
        Guid categoryChapterId,
        Guid chapterId,        
        float readiness,
        decimal costChapter,
        string comment,
        List<SubChapter> subChapters)
    {
        CategoryChapterId = categoryChapterId;
        ChapterId = chapterId;
        Readiness = readiness;
        CostChapter = costChapter;
        Comment = comment;
        SubChapters = subChapters;
    }

    public static Chapter Create(
        Guid categoryChapterId,
        Guid chapterId,
        float readiness,
        decimal costChapter,
        string comment, List<SubChapter> subChapters)
    {
        Chapter chapter = new Chapter(categoryChapterId,chapterId, readiness, costChapter, comment, subChapters);
        return chapter;
    }

    private Chapter(
        Guid id,
        Guid categoryChapterId,
        float rd,
        decimal costChap,
        string com,
        Guid specId,
        List<SubChapter> subChapters)
    {
        ChapterId = id;
        Readiness = rd;
        CostChapter = costChap;
        Comment = com;
        SpecificationId = specId;
        SubChapters = subChapters;
        CategoryChapterId = categoryChapterId;
    }

    public static Chapter Create(
        Guid id,
        Guid categoryChapterId,
        float rd,
        decimal costChap,
        string com,
        Guid specId,
        List<SubChapter> subChapters)
    {
        Chapter chapter = new Chapter(id, categoryChapterId, rd, costChap, com, specId, subChapters);
        return chapter;
    }

    private Chapter(Guid id,float rd, decimal costChap, string com, Guid specId)
    {
        ChapterId = id;
        Readiness = rd;
        CostChapter = costChap;
        Comment = com;
        SpecificationId = specId;
    }




    public Chapter(Guid chapId, Guid specId, string specName, int countDevice)
    {
        ChapterId = chapId;
        SpecificationId = specId;
        SpecName = specName;
        CountDevice = countDevice;
    }

    private Chapter(
        Guid id,
        string chapterName,
        float rd,
        decimal costChap,
        string com,
        Guid catChapId
    )
    {
        ChapterId = id;
        ChapterName = chapterName;
        Readiness = rd;
        CostChapter = costChap;
        Comment = com;
        CategoryChapterId = catChapId;
    }

    


    public static Chapter Create( Guid id, Guid specId, string specName, string chapterName, int countDevice)
    {
        Chapter chapter = new Chapter(id,specId, specName, countDevice);
        return chapter;
    }

    /// <summary>
    /// Создание модели без дополнительных связей
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rd">Готовность раздела</param>
    /// <param name="costChap">Итоговая стоимость раздела</param>
    /// <param name="com">Примечание</param>
    /// <param name="specId">Индификатор Спецификации</param>
    /// <param name="categoryId">Индификатор категории устройства</param>
    /// <returns></returns>
    public static (Chapter chp, string err) Create(
        Guid id,
        float rd,
        decimal costChap,
        string com,
        Guid specId
    )
    {
        Chapter chapter = new Chapter(id, rd, costChap, com, specId);
        return (chapter, "Без ошибок");
    }


    public static (Chapter chp, string err) CreateDetail(
        Guid id,
        string chapterName,
        float rd,
        decimal costChap,
        string com,
        Guid catChapId
    )
    {
        Chapter chapter = new Chapter(id, chapterName, rd, costChap, com, catChapId);
        return (chapter, "Без ошибок");
    }

    public Guid ChapterId { get; }

    public string SpecName { get; set; } = string.Empty;

    /// <summary>
    /// Название раздела
    /// </summary>
    public string ChapterName { get; } = string.Empty;

    /// <summary>
    /// Готовность раздела
    /// </summary>
    public float Readiness { get; } = 0.0f;

    /// <summary>
    /// Итоговая стоимость раздела
    /// </summary>
    public decimal CostChapter { get; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string Comment { get; } = string.Empty;

    public Guid SpecificationId { get; }
    //public Guid CategoryDeviceId { get; }

    public int CountDevice { get; }

    public List<SubChapter> SubChapters { get; } = [];
    public Guid CategoryChapterId { get;}
}
