using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            var sortedByBirthDate = people.OrderBy(person => person.Birthdate).ToArray();
            var firstTenPeople = people.Take(10);
            var skipTenPeople = people.Skip(10).Take(10);
            // Math functions
            var maxsalary = people.Max(person => person.Salary);
            var minsalary = people.Min(person => person.Salary);
            var averagesalary = people.Average(person => person.Salary);

            int pagesize = 10;
            int pagenumber = 3;

            var pagination = people.Skip((pagenumber - 1) * pagesize).Take(pagesize);
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

            Console.WriteLine();
            Console.WriteLine("***** BIRTH DATE *****");
            foreach (Person p in sortedByBirthDate)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} | {p.Birthdate}");
            }

            Console.WriteLine();
            Console.WriteLine("***** TAKE 10 PEOPLE *****");
            foreach (Person p in firstTenPeople)
            {
                Console.WriteLine($"ID - [{p.Id}]{p.FirstName} {p.LastName}");
            }

            //Console.WriteLine();
            //Console.WriteLine("***** SKIP 10 PEOPLE *****");
            //foreach (Person p in skipTenPeople)
            //{
            //    Console.WriteLine($"ID - [{p.Id}]{p.FirstName} {p.LastName}");
            //}

            Console.WriteLine();
            Console.WriteLine("***** PAGINATION *****");
            foreach (Person p in pagination)
            {
                Console.WriteLine($"ID - [{p.Id}]{p.FirstName} {p.LastName}");
            }
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
