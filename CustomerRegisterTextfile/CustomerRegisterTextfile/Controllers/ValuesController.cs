using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using CustomerRegisterTextfile.Model;

namespace CustomerRegisterTextfile.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        static string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PersonsShort.txt");

        string[] customers = System.IO.File.ReadAllLines(path);
        
        [HttpGet, Route("GetCustomer")]
        public IActionResult GetCustomer(int? id)
        {
            List<Customer> customerList = getCustomers();
            
            if (id == null)
            {
                return BadRequest("Id:et måste vara ett number.");
            }
            if (id <= 0)
            {
                return BadRequest("Id:et måste var högre än 0.");
            }

            for (int i = 0; customerList.Count > i; i++)
            {
                if (id == customerList[i].Id)
                {
                    return Ok(customerList[i]);
                }
            }

            return StatusCode(404, $"Kunden med id={id} finns inte!");
        }

        [HttpGet, Route("GetCustomerBriefly")]
        public IActionResult GetCustomerBriefly(bool briefMode, int? id)
        {
            List<Customer> customerList = getCustomers();

            if (id == null)
            {
                return BadRequest("Id:et måste vara ett number.");
            }
            if (id <= 0)
            {
                return BadRequest("Id:et måste var högre än 0.");
            }

            for (int i = 0; customerList.Count > i; i++)
            {
                if (id == customerList[i].Id)
                {
                    if (!briefMode)
                    {
                        return Ok(customerList[i]);
                    }
                    else
                    {
                        return Ok($"{customerList[i].FirstName} {customerList[i].LastName}");
                    }
                }
            }

            return StatusCode(404, $"Kunden med id={id} finns inte!");
        }

        [HttpGet, Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            List<Customer> customersToReturn = getCustomers();

            List<Customer> listToReturn = new List<Customer>();

            for (int i = 1; getCustomers().Count > i; i++ )
            {
                listToReturn.Add(customersToReturn[i]);
            }

            return Ok(listToReturn);
        }

        public List<Customer> getCustomers()
        {
            List<Customer> customerListToReturn = new List<Customer>();

            foreach (string customer in customers)
            {
                string[] linesSplittedByComa = customer.Split(',');

                Customer customerForAssigningValueTo = new Customer();

                int.TryParse(linesSplittedByComa[0], out int x);
                int.TryParse(linesSplittedByComa[5], out int y);

                customerForAssigningValueTo.Id = x;
                customerForAssigningValueTo.FirstName = linesSplittedByComa[1];
                customerForAssigningValueTo.LastName = linesSplittedByComa[2];
                customerForAssigningValueTo.Email = linesSplittedByComa[3];
                customerForAssigningValueTo.Gender = linesSplittedByComa[4];
                customerForAssigningValueTo.Age = y;

                customerListToReturn.Add(customerForAssigningValueTo);
            }

            return customerListToReturn;
        }
    }
}
