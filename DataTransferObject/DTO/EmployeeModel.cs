using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTO
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }
        public EmpDetailModel EmpDetailModel { get; set; }
    }
}
