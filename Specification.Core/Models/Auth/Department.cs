using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models.Auth
{
    public class Department
    {
        private Department(Guid id, string DepName, string ShortDepName)
        {
            Id = id;
            DepartmentName = DepName;
            DepShortName = ShortDepName;
        }

        public Guid Id { get; private set; }
        public string DepartmentName { get; private set; } = string.Empty;

        public string DepShortName { get; private set; } = string.Empty;

        public static Department Create(Guid id, string depName, string shortDepName)
        {
            Department deps = new Department(id, depName, shortDepName);
            return deps;
        }
    }
}
