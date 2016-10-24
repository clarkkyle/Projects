using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    public class Person
    {
        private string _language;
        private string _name;
        private int _age;

        public Person(string language, string name, int age)
        {
            _language = language;
            _name = name;
            _age = age;
        }

        public string Name
        {
            get
            {
                return _name.ToUpper();

            }
            set { _name = value; }
        }

        public string Address { get; set; }

        internal void Speak()
        {
            ConsoleHelper.PrintToConsole($"Hello my name is {Name} and I am {_age} years old and speak {_language}");
        }

        public void Walk()
        {
            ConsoleHelper.PrintToConsole($"{Name} is walking!");

        }



    }
}
