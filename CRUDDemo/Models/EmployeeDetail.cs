using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDDemo.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Department { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string DateEmployed { get; set; }

    }
}
