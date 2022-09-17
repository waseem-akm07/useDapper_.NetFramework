using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTO
{
    public class EmpDetailModel
    {
        public int DetailId { get; set; }
        public string FatherName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int EmployeeId { get; set; }
    }
}
