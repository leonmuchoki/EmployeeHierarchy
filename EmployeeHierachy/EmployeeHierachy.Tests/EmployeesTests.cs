using EmployeesHierachy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeHierachy.Tests
{
    public class EmployeesTests
    {
        [Fact]
        public void returnsFalseIfSalaryIsNotInt()
        {
            List<string> salaryList = new List<string>();
            salaryList.Add("100000");
            salaryList.Add("none");
            salaryList.Add("500000");

            Employees s = new Employees();
            var isNotValid = s.validateSalaries(salaryList);

            Assert.True(isNotValid);
        }
    }
}
