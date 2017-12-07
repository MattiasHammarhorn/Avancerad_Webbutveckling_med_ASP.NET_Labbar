using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {

            databaseContext.Add(customer);
            databaseContext.SaveChanges();

            return Ok($"Customer with id: {customer.Id} has been successsfully added.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Customer customerToRemove = databaseContext.Customers.Find(id);
            databaseContext.Remove(customerToRemove);
            databaseContext.SaveChanges();

            return Ok($"Customer with id: {customerToRemove.Id} has been successsfully removed.");
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

            databaseContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Customer> customerList = new List<Customer>();

            foreach(Customer customer in databaseContext.Customers)
            {
                customerList.Add(customer);
            }

            return Ok(customerList);
        }
    }
}
