namespace Specification.Core.Models
{
    public class CategoryChapter
    {

        CategoryChapter(Guid catChapId, string name)
        {
            CategoryChapterId = catChapId;
            Name = name;
        }

        public static CategoryChapter Create(Guid catChapId, string name) 
        {
            CategoryChapter catChap = new CategoryChapter(catChapId, name);
            return catChap;
        }

        CategoryChapter(Guid catChapId, string name, List<ResponsibleCatChapter> rsp)
        {
            CategoryChapterId = catChapId;
            Name = name;
            ResponsiblePersons = rsp;
        }

        public static CategoryChapter Create(Guid catChapId, string name, List<ResponsibleCatChapter> rsp)
        {
            CategoryChapter catChap = new CategoryChapter(catChapId, name, rsp);
            return catChap;
        }

        public Guid CategoryChapterId { get; }        
        public string Name { get; } = string.Empty;
        public List<ResponsibleCatChapter> ResponsiblePersons { get; } = [];
    }
}
