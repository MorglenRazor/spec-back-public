using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccessAuth.Repositories.Base
{
    public abstract class BaseRepositories(AuthDataBaseContext dbContext)
    {
        protected readonly AuthDataBaseContext DataBaseContext = dbContext;
    }
}
