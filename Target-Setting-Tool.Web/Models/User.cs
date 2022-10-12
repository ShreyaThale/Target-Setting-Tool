using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target_Setting_Tool.Web.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey( "Role" )]
        public Guid RoleId { get; set; }
        [DataType( DataType.EmailAddress )]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeCode { get; set; }
        [DataType( DataType.DateTime )]
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        [DataType( DataType.DateTime )]
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        [DataType( DataType.DateTime )]
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public virtual Role Role { get; set; }
    }
}
