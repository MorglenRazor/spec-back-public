using Specification.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Abstractions.Service
{
    public interface IUomService
    {
        Task<UnitOfMeasure> Get(int id);
    }
}
