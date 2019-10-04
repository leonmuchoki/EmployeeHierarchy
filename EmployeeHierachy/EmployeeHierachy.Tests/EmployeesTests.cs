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

        [Fact]
        public void returnsFalseIfEmployeeHasMoreThanOneManager()
        {
            List<string> employeeIdList = new List<string>();
            employeeIdList.Add("1");
            employeeIdList.Add("2");
            employeeIdList.Add("2");

            Employees s = new Employees();
            var hasMoreThanOneMngr = s.hasOneManager(employeeIdList);

            Assert.False(hasMoreThanOneMngr);
        }

        [Fact]
        public void returnsFalseIfMoreThanOneCEO()
        {
            List<string> managerIdList = new List<string>();
            managerIdList.Add("1");
            managerIdList.Add("3");
            managerIdList.Add("2");
            managerIdList.Add("");
            managerIdList.Add("");

            Employees s = new Employees();
            var hasOneCEO = s.oneCEO(managerIdList);

            Assert.False(hasOneCEO);
        }
    }
}
