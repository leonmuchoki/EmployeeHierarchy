using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeesHierachy
{
    public class Employees
    {
        string _csv_file_path;
        char _csv_separator;
        List<string> listEmpIds;
        List<string> listManagerIds;
        List<string> listSalaries;

        public Employees()
        {

        }

        public Employees(string csv_path, string csvSeparator=",")
        {
            _csv_file_path = csv_path;
            _csv_separator = char.Parse(csvSeparator);

           
            ReadAndParseCSV();

            //validations
            validateSalaries(listSalaries);
            hasOneManager(listEmpIds);
            oneCEO(listManagerIds);
            managerAlsoAnEmployee();
        }

        public void ReadAndParseCSV()
        {
            using (var reader = new StreamReader(_csv_file_path))
            {
                try
                {
                    listEmpIds = new List<string>();
                    listManagerIds = new List<string>();
                    listSalaries = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(_csv_separator);

                        listEmpIds.Add(values[0]);
                        listManagerIds.Add(values[1]);
                        listSalaries.Add(values[2]);
                    }
                }
                catch(Exception ex)
                {
                }
            }
        }

        public bool validateSalaries(List<string> listSalaries)
        {
            bool isValidInt;
            int _sal;
            foreach (var sal in listSalaries)
            {
                if (!int.TryParse(sal, out _sal))
                {
                    isValidInt = false;
                    break;
                }
            }
            isValidInt = true;

            return isValidInt;
        }

        public bool hasOneManager(List<string> _listEmpIds)
        {
            bool _hasOneManager;
            if (_listEmpIds.Count != _listEmpIds.Distinct().Count())
            {
                _hasOneManager = false;
            }
            else
            {
                _hasOneManager = true;
            }
            return _hasOneManager;
        }

        public bool oneCEO(List<string> _listManagerIds)
        {
            bool hasOneCeo;
            int _countCEOs=0;
            foreach (var mgrId in _listManagerIds)
            {
                if (string.IsNullOrEmpty(mgrId))
                {
                    _countCEOs += 1;
                }
            }
            if (_countCEOs > 1)
            {
                hasOneCeo = false;
            } else
            {
                hasOneCeo = true;
            }
            return hasOneCeo;
        }

        public bool managerAlsoAnEmployee()
        {
            bool mngrIsEmployee = true ;
            var list1 = listManagerIds.Where(i => !listEmpIds.Contains(i)).ToList();
            if (list1.Count > 0)
                mngrIsEmployee = false;

            return mngrIsEmployee;
           
        }

        public long managerSalaryBudget(string managerId, List<string> _listSalaries)
        {
            long _mngrBudget=0;

            // get employees budgets
            foreach (var item in listManagerIds.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (value == managerId)
                {
                    _mngrBudget += long.Parse(_listSalaries[index]);
                }
            }

            // get manager budget:
            foreach (var item in listEmpIds.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (value == managerId)
                {
                    _mngrBudget += long.Parse(_listSalaries[index]);
                    break;
                }
            }


            return _mngrBudget;
        }

    }
}
