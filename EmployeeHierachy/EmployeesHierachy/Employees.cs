using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeesHierachy
{
    public class Employees
    {
        string _csv_file_path;
        char _csv_separator;
        public Employees(string csv_path, string csvSeparator)
        {
            _csv_file_path = csv_path;
            _csv_separator = char.Parse(csvSeparator);
        }

        public void ReadCSVLine()
        {
            using (var reader = new StreamReader(_csv_file_path))
            {
                List<string> listEmpIds = new List<string>();
                List<string> listManagerIds = new List<string>();
                List<decimal> listSalaries = new List<decimal>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(_csv_separator);

                    listEmpIds.Add(values[0]);
                    listManagerIds.Add(values[1]);
                    listSalaries.Add(decimal.Parse(values[2]));
                }
            }
        }

    }
}
