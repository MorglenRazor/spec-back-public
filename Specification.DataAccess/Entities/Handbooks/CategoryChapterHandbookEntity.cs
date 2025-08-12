namespace Specification.DataAccess.Entities.Handbooks
{
    public class CategoryChapterHandbookEntity
    {
        public Guid CategoryChapterId { get; set; }

        /// <summary>
        /// Название категории (прим. Электрооборудование)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Связь с ChapterEntity
        /// </summary>
        public List<ChapterEntity> Chapters { get; set; } = [];


        #region Ответсвтвенные

        public List<RespChapterEntity> RespPersons { get; set; } = [];

        #endregion

        /// <summary>
        /// Список подразделов
        /// </summary>
        public List<CategoryDeviceEntity> CategoryDevice { get; set; } = [];
    }
}