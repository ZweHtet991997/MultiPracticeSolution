using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CRUDOperationWithAjax.Models
{
    [Table("Tbl_Employee")]
    public class EmployeeModel
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("EmployeeCode")]
        [StringLength(100)]
        public string EmployeeCode { get; set; }

        [Column("FullName")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Column("Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("Address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Column("PhoneNumber")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Column("DOB")]
        public DateTime DOB { get; set; }
    }
}
