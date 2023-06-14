using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{
    internal class Teacher
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Constructor
        public Teacher(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Teacher(string email, string password)
        {
            Name = "";
            Email = email;
            Password = password;
        }

        public Teacher()
        {
            Name = "";
            Email = "";
            Password = "";
        }
        // Other methods and functionality can be added here
    }
    internal class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Constructor
        public Student(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Student(string email, string password)
        {
            Name = "";
            Email = email;
            Password = password;
        }

        public Student()
        {
            Name = "";
            Email = "";
            Password = "";
        }
        // Other methods and functionality can be added here
    }
}
