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
            Console.WriteLine("***** First Person *****");
            Console.WriteLine(firstPerson);
            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - ");
            Console.WriteLine();
            Console.WriteLine("***** Last Person *****");
            Console.WriteLine(lastPerson);
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
