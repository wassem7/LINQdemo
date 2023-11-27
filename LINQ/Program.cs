using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = ReadPeopleData();

            var firstPerson = people.FirstOrDefault();
            var lastPerson = people.LastOrDefault();
            var firstnamestartsWithA = people.FirstOrDefault(
                person => person.FirstName.StartsWith("A")
            );

            var onlyfirstName = people.SingleOrDefault(person => person.Id == 10004);

            // Math functions

            var maxsalary = people.Max(person => person.Salary);
            var minsalary = people.Min(person => person.Salary);
            var averagesalary = people.Average(person => person.Salary);
            Console.WriteLine("***** First Person *****");
            Console.WriteLine(firstPerson);

            Console.WriteLine();
            Console.WriteLine("***** Last Person *****");
            Console.WriteLine(lastPerson);

            Console.WriteLine();
            Console.WriteLine("***** Starts with A *****");
            Console.WriteLine(firstnamestartsWithA);

            Console.WriteLine();
            Console.WriteLine("***** Starts with A only *****");
            Console.WriteLine(onlyfirstName);

            Console.WriteLine();
            Console.WriteLine("***** MAX SALARY *****");
            Console.WriteLine(maxsalary);

            Console.WriteLine();
            Console.WriteLine("***** MIN SALARY *****");
            Console.WriteLine(minsalary);

            Console.WriteLine();
            Console.WriteLine("***** AVERAGE SALARY *****");
            Console.WriteLine(averagesalary);
        }

        static Person[] ReadPeopleData()
        {
            using (var reader = new StreamReader("people.json"))
            {
                string jsondata = reader.ReadToEnd();
                var people = JsonConvert.DeserializeObject<Person[]>(jsondata);
                return people;
            }
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID-[{Id}] | {FirstName} {LastName} | {City} | {Salary} | {Birthdate.ToShortDateString()}";
        }
    }
}
