using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    public class Instructor : Person
    {
        public Instructor (string lanaguage, string name, int age) : base(lanaguage,name,age)
        {


        }
        public string Department { get; set; }

        public void InstructorInfo()
        {
            ConsoleHelper.PrintToConsole($"{Name} is an instructor in the {Department} department");
        }
    }
}
