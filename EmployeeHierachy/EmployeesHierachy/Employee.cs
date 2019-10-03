using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesHierachy
{
    public class Employee
    {
        public string employeeId { get; set; }
        public string managerId { get; set; }
        public Decimal salary { get; set; }
    }
}
