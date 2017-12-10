using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegisterDatabase.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        

        public DatabaseContext(DbContextOptions<DatabaseContext> context ): base(context)
        {

        }

        // Non-functional method
        //public List<Customer> SeedDatabaseWithCustomersFromTextfile()
        //{
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Customers.txt");

        //    string[] customersFromTextfile = System.IO.File.ReadAllLines(path);

        //    List<Customer> customersToSeed = new List<Customer>();

        //    for (int i = 1; customersFromTextfile.Length > i; i++)
        //    {
        //        string[] customerLineSplitByComma = customersFromTextfile[i].Split(',');

        //        Customer customerForAssigningValueTo = new Customer();
                
        //        Gender parsedGenderType = (Gender)Enum.Parse(typeof(Gender), customerLineSplitByComma[3]);
        //        int.TryParse(customerLineSplitByComma[4], out int parsedCustomerAge);
                
        //        customerForAssigningValueTo.FirstName = customerLineSplitByComma[0];
        //        customerForAssigningValueTo.LastName = customerLineSplitByComma[1];
        //        customerForAssigningValueTo.Email = customerLineSplitByComma[2];
        //        customerForAssigningValueTo.GenderType = parsedGenderType;
        //        customerForAssigningValueTo.Age = parsedCustomerAge;

        //        customersToSeed.Add(customerForAssigningValueTo);
        //    }

        //    return customersToSeed;
        //}
    }
}
