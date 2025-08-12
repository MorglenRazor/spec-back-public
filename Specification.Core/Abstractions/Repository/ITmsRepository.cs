using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface ITmsRepository
    {
        Task UpdateGenField(int id, TmsDep model);
    }
}
