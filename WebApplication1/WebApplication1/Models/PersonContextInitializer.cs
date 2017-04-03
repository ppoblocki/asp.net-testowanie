using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonContextInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext context)
        { 
            var cars = new List<Car>
            {
                new Car
                {
                    Name = "Audi A4",
                    HorsePower = 200,
                    Year = 2017,
                },
                new Car
                {
                    Name = "BMW Series 3",
                    HorsePower = 200,
                    Year = 2017,
                },
                new Car
                {
                    Name = "Mercedes-Benz C-Class",
                    HorsePower = 200,
                    Year = 2017,
                }
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();

            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Login = "JanK",
                    CarID = 1,
                },
                new Person
                {
                    FirstName = "Joanna",
                    LastName = "Kowalska",
                    Login = "JoannaK",
                    CarID = 2,
                },
                new Person
                {
                    FirstName = "Jeremy",
                    LastName = "Clarkson",
                    Login = "JC",
                    CarID = 3,
                }
            };
            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}