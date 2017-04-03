using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonContext : DbContext, IPersonContext
    {
        public PersonContext() : base("PersonContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        IQueryable<Person> IPersonContext.People
        {
            get { return People; }
        }

        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Set<T>().Remove(entity);
        }

        int IPersonContext.SaveChanges()
        {
            return SaveChanges();
        }

        public Car FindCarById(int id)
        {
            Car car = (from c in Set<Car>()
                       where c.CarID == id
                       select c).FirstOrDefault();
            return car;
        }

        public Person FindPersonById(int id)
        {
            Person person = (from p in Set<Person>()
                             where p.PersonID == id
                             select p).FirstOrDefault();
            return person;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}