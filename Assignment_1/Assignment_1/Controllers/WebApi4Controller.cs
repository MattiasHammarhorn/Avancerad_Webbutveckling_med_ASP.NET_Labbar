using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_1.Controllers
{
    [Route("api/webapi4")]
    public class WebApi4Controller : Controller
    {
        [HttpPost, Route("CreatePerson")]
        public IActionResult CreatePerson(SimplePerson person)
        {
            return Ok($"Du har angett {person.Name} som är {person.Age}.");
        }

        [HttpPost, Route("ValidatePerson")]
        public IActionResult ValidatePerson(SimplePerson person)
        {
            if (person.Age < 0 && person.Name.Length > 20 || person.Age > 120 && person.Name.Length > 20)
            {
                return BadRequest("The name can only be 20 characters long and the age can only be between 0 and 120");
            }
            else if (person.Age < 0 || person.Age > 120)
            {
                return BadRequest("The age can only be between 0 and 120");
            }
            else if (person.Name.Length > 20)
            {
                return BadRequest("The name can only be 20 characters long.");
            }
            else
            {
                return Ok($"Du har angett {person.Name} som är {person.Age}.");
            }
        }

        [HttpPost, Route("ValidateWithAttributes")]
        public IActionResult ValidateWithAttributes(SimplePerson person)
        {
            if (ModelState.IsValid)
            {
                return Ok($"Du har angett {person.Name} som är {person.Age}.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
