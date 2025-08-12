using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Application.Interfaces.Auth
{
    internal interface ICheckAuth
    {
        public bool CheckUser(Guid id);
    }
}
