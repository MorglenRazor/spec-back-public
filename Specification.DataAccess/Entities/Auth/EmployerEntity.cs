using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using System.Security.Principal;

namespace Specification.DataAccess.Entities.Auth
{
    public class EmployerEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        //public bool IsResp { get; set; } = false;
        public bool IsActual { get; set; } = true;
        public Guid DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }
        public List<RoleEntity> Roles { get; set; } = [];
        public List<RespChapterEntity> ResponsibleChapter { get; set; } = [];

        public List<ConstructionDepartmentEntity> ConstructionDepResp { get; set; } = [];

        public List<AccountingDepartmentEntity> AccountingDepResp { get; set; } = [];
        public List<TmsDepartmentEntity> TmsDepResp { get; set; } = [];
        public List<TcDepartmentEntity> TcDepResp { get; set; } = [];
        public List<WarehouseDepartmentEntity> WarehouseDepResp { get; set; } = [];
    }
}
