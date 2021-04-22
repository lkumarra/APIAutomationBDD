using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.Deserializer.GetEmployee
{
    public class GetEmployeeRoot
    {
       
     public string status { get; set; }
     public List<Datum> data { get; set; }
    }
}
