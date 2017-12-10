using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(DatabaseContext databaseContext, ILogger<CustomerController> logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Add(Customer customerToAdd)
        {
            customerToAdd.CreatedOn = DateTime.Now;
            customerToAdd.LastUpdatedOn = DateTime.Now;
            databaseContext.Add(customerToAdd);
            databaseContext.SaveChanges();

            logger.LogInformation("Add method run for new Customer with id: " + customerToAdd.Id);
            return Ok($"Customer with id: {customerToAdd.Id} has successsfully been added to the records.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Customer customerToRemove = databaseContext.Customers.Find(id);
            databaseContext.Remove(customerToRemove);
            databaseContext.SaveChanges();

            logger.LogInformation("Delete method run for Customer with id: " + customerToRemove.Id);
            return Ok($"Customer with id: {customerToRemove.Id} has successsfully been removed to the records.");
        }

        // /api/customers/?id=123
        // /api/customers/123
        [HttpGet, Route("{id:int}")]
        public IActionResult GetCustomer(int id)
        {
            Customer customerToReturn = databaseContext.Customers.Find(id);
            return Ok(customerToReturn);
        }

        [HttpPut]
        public IActionResult Update(Customer customerToUpdate)
        {
            Customer databaseCustomer = databaseContext.Customers.SingleOrDefault(dbc => dbc.Id == customerToUpdate.Id);
            databaseCustomer.FirstName = customerToUpdate.FirstName;
            databaseCustomer.LastName = customerToUpdate.LastName;
            databaseCustomer.Email = customerToUpdate.Email;
            databaseCustomer.GenderType = customerToUpdate.GenderType;
            databaseCustomer.Age = customerToUpdate.Age;
            databaseCustomer.LastUpdatedOn = DateTime.Now;

            databaseContext.SaveChanges();
            return Ok($"Customer with id: {customerToUpdate.Id} has successsfully been updated to the records.");
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Customer> customerList = new List<Customer>();

            foreach(Customer customer in databaseContext.Customers)
            {
                customerList.Add(customer);
            }
            logger.LogInformation("List method run");
            return Ok(customerList);
        }

        [HttpPost, Route("Seed")]
        public IActionResult Seed()
        {
            foreach(CustomerRegisterDatabase.Entities.Customer existingCustomerToBeDeleted in databaseContext.Customers)
            {
                databaseContext.Customers.Remove(existingCustomerToBeDeleted);
            }
            databaseContext.SaveChanges();

            List<Customer> customersToSeed = databaseContext.SeedDatabaseWithCustomersFromTextfile();

            foreach(Customer customerToBeSeeded in customersToSeed)
            {
                customerToBeSeeded.CreatedOn = DateTime.Now;
                customerToBeSeeded.LastUpdatedOn = DateTime.Now;
                databaseContext.Customers.Add(customerToBeSeeded);
                databaseContext.SaveChanges();
            }

            return Ok($"Database has successsfully been seeded.");
        }
    }
}
