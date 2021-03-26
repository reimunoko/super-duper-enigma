using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.UI.Model;

namespace EmployeeService.UI.Business.Model.Dto
{
    public class DepartmentDto  
    {
      
        public int Id { get; set; }
        
        [AcmeGridColumn("Name")]
        [Required]
        public string Name { get; set; }

        [AcmeGridColumn("Location")]
        [Required]
        public string Location { get; set; }


        public bool IsDisabled { get; set; } = true;
    }
}
