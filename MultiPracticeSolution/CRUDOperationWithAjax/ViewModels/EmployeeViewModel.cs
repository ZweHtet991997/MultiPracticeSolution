using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CRUDOperationWithAjax.Models;

namespace CRUDOperationWithAjax.ViewModels
{
    public class EmployeeViewModel
    {
        public ResponseModel response { get; set; }
        public int ID { get; set; }
        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }
        //Use to bind in Edit form
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        public string? DOB_Str { get; set; }
    }
}
