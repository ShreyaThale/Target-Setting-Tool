using System.ComponentModel.DataAnnotations;

namespace Target_Setting_Tool.Web.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name Should Contain Alphabet Letters Only")]
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
