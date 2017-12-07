using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_1.Controllers
{
    [Route("api/demo3api")]
    public class Demo3ApiController : Controller
    {
        [HttpGet, Route("LampSite")]
        public IActionResult LampSite(bool lampMode)
        {
            string bgColor = "";

            if (lampMode == true)
                bgColor = "yellow";
            else if (lampMode == false)
                bgColor = "gray";

            string htmlToReturn = $"<body style='background-color:{bgColor}'></body>";

            return Content(htmlToReturn, "text/html");
        }

        [HttpGet, Route("ShareChocolate")]
        public IActionResult ShareChocolate(int numberOfPersons)
        {
            decimal amountOfChocolate = 25;

            if (numberOfPersons <= 0)
                return BadRequest("För lite personer!");

            decimal answer = amountOfChocolate / numberOfPersons;

            return Ok(answer);
        }

        [HttpGet, Route("GetOrderNumber")]
        public IActionResult GetOrderNumber(string orderRequest)
        {
            // Match match = Regex.Match(orderRequest, @"^([A-Z][A-Z])-(\d{4})$", RegexOptions.IgnoreCase);
            string[] orderToParse = orderRequest.Split('-');

            Match match1 = Regex.Match(orderToParse[0], @"^[a-zA-Z]+$");
            Match match2 = Regex.Match(orderToParse[1], @"^[0-9]+$");

            if(!match1.Success)
            {
                return BadRequest("De två första positionerna måste vara bokstäver!");

            } else if(orderToParse[0].Length != 2)
            {
                return BadRequest("De första positionerna måste vara 2 bokstäver!");

            } else if (!match2.Success)
            {
                return BadRequest("De fyra andra positionerna måste vara nummer!");

            } else if (orderToParse[1].Length != 4)
            {
                return BadRequest("De andra positionerna måste vara fyra nummer!");
            }

            int numbersToCompare = int.Parse(orderToParse[1]);
            if (numbersToCompare < 3001)
                return Ok($"Order {orderRequest} hittades i databasen!");
            else
                return NotFound($"Kunde inte hitta order {orderRequest}");
        }

        [HttpGet, Route("FindUser")]
        public IActionResult FindUser(string userToFind)
        {

            if (userToFind == "Stewie")
            {
                throw new Exception("DATA ERROR!");

            } else if (userToFind == "Peter")
            {
                return Content("<img src='https://upload.wikimedia.org/wikipedia/commons/7/79/Operation_Upshot-Knothole_-_Badger_001.jpg'></img>", "text/html");

            } else if (userToFind == "Lois" || userToFind == "Meg" || userToFind == "Chris" || userToFind == "Brian")
            {
                return Content("<img src='https://benahrens.com/wp-content/uploads/2015/09/thumbs-up-happy-e1444767436109.jpg'></img>", "text/html");
            }

            return Content("<img src='https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/SMirC-thumbsdown.svg/120px-SMirC-thumbsdown.svg.png'></img>", "text/html");
        }
    }
}
