using Specification.DataAccess.Entities.Auth;
using Specification.DataAccess.Entities.Handbooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Entities
{
    public class RespChapterEntity
    {

        public Guid Id { get; set; }

        public Guid EmpId { get; set; }
        public EmployerEntity? Responsible { get; set; }

        public Guid CategoryChapterId { get; set; }
        public CategoryChapterHandbookEntity? CategoryChapter { get; set; }
    }
}
