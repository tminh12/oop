using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Person
    {
        public string name;
        public string address;
        public double salary;

        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }
        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("You must input Salary.");
            }

            if (!double.TryParse(sSalary, out double salary))
            {
                throw new Exception("You must input digit.");
            }

            if (salary <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }

            return new Person(name, address, salary);
        }

        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine("Information of Person you have entered:");
            Console.WriteLine("Name: " + person.name);
            Console.WriteLine("Address: " + person.address);
            Console.WriteLine("Salary: " + person.salary.ToString("F1"));
        }

        public static Person[] SortBySalary(Person[] persons)
        {
            if (persons == null || persons.Length == 0)
            {
                throw new Exception("Can't Sort Person");
            }
            int n = persons.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (persons[j].salary > persons[j + 1].salary)
                    {
                        Person temp = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = temp;
                    }
                }
            }
            return persons;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Management Person programer");
            Person[] persons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Information of Person");
                Console.Write("Please input name: ");
                string name = Console.ReadLine();
                Console.Write("Please input address: ");
                string address = Console.ReadLine();
                Person person = null;
                while (person == null)
                {
                    Console.Write("Please input salary: ");
                    string sSalary = Console.ReadLine();
                    try
                    {
                        person = Person.InputPersonInfo(name, address, sSalary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                persons[i] = person;
            }
            try
            {
                persons = Person.SortBySalary(persons);

                foreach (Person p in persons)
                {
                    Person.DisplayPersonInfo(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
