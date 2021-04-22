using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.Serializer.CreateEmployee
{
    public class CreateEmployee
    {
        private string nameKey = "name";
        private string salaryKey = "salary";
        private string ageKey = "age";
        private string name;
        private string salary;
        private string age;

        public CreateEmployee(string name, string salary, string age)
        {
            this.name = name;
            this.salary = salary;
            this.age = age;
        }

        public string GetCreateEmployeePayload()
        {
            JsonObject json = new JsonObject();
            json.Add(nameKey, name);
            json.Add(salaryKey, salary);
            json.Add(ageKey, age);
            return json.ToString();
        }
    }
}
