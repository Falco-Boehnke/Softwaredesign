using System;


namespace Softwaredesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] leute =
            {
                new Person("Falco", "Böhnke", 26),
                new Person("Hubert", "Hubert", 68),
                new Person("Yo", "Mamoth", 20),
                new Person("Lost", "Track", 2),
                new Person("Nowwe", "Done", 99)
            };

            foreach(Person person in leute)
            {
                if(person.Age > 20)
                    Console.WriteLine(person.ToString());
            }
        }
    }

public class Person
{
   public string FirstName;
   public string LastName;
   public int Age;

    public Person(string firstname, string lastname, int age)
    {
        FirstName = firstname;
        LastName = lastname;
        Age = age;
        
    }

   public override string ToString() 
   { 
        return FirstName + " " + LastName + " Alter: " + Age;
    }
}
}
