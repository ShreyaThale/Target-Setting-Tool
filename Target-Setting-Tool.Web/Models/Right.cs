using System.ComponentModel.DataAnnotations;

namespace Target_Setting_Tool.Web.Models
{
    public class Right
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CreatedBy { get; set; }

        [DataType( DataType.DateTime )]
        public DateTime CreatedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        [DataType( DataType.DateTime )]
        public DateTime? ModifiedDate { get; set; }


        public bool IsDeleted { get; set; }

        [DataType( DataType.DateTime )]
        public DateTime? DeletedDate { get; set; }

        public Guid? DeletedBy { get; set; }
    }
}
