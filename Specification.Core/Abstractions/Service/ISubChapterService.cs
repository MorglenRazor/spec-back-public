using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service
{
    public interface ISubChapterService
    {
        Task<List<SubChapter>> GetSubChapterDetail();

        Task<List<SubChapter>> GetSubChapterProfile(List<Guid> statusIds);
    }
}
