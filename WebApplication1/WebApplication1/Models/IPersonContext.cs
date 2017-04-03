using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IPersonContext
    {
        IQueryable<Person> People { get; }
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        int SaveChanges();
        Person FindPersonById(int id);
        Car FindCarById(int id);
    }
}
