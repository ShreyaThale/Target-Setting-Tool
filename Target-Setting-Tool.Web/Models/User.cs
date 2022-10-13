using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target_Setting_Tool.Web.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name can only contain alphabets")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 character long")]
        public string Name { get; set; }
        [ForeignKey( "Role" )]
        public Guid RoleId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required, RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4})*$", ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }
        [MinLength(10, ErrorMessage = "Mobile No. must be between 10 to 15 digits."), MaxLength(15, ErrorMessage = "Mobile No. must be between 10 to 15 digits.")]
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
