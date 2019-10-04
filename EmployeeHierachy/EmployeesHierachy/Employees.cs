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

        public Employees(string csv_path, string csvSeparator=",")
        {
            _csv_file_path = csv_path;
            _csv_separator = char.Parse(csvSeparator);
            ReadAndParseCSV();
            validateSalaries();
            oneCEO();
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

        public bool validateSalaries()
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

        public bool hasOneManager()
        {
            bool _hasOneManager;
            if (listEmpIds.Count != listEmpIds.Distinct().Count())
            {
                _hasOneManager = false;
            }
            else
            {
                _hasOneManager = true;
            }
            return _hasOneManager;
        }

        public bool oneCEO()
        {
            bool hasOneCeo;
            int _countCEOs=0;
            foreach (var mgrId in listManagerIds)
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

    }
}
