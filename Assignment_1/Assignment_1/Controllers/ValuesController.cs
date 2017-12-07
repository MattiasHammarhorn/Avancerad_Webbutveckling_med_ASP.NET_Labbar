using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Assignment_1.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Matheus", "Hammerhrón" };
        }

        [HttpGet, Route("HelloWorld")]
        public string HelloWorld()
        {
            return "Hell World";
        }

        [HttpGet, Route("CurrentWeekDay")]
        public string GetCurrentWeekDay()
        {
            //Thread.CurrentThread.CurrentCulture = 
            return "Idag är det " + DateTime.Today.DayOfWeek.ToString().ToLower();
        }
        
        [HttpGet, Route("ClicheOfTheDay")]
        public string ClicheOfTheDay()
        {
            string message = "";
            string weekDay = DateTime.Today.DayOfWeek.ToString();

            if (weekDay == "monday")
                message = "Uh - oh. Sounds like somebody’s got a case of the mondays.";
            else if (weekDay == "tuesday")
                message = "Uh - oh. Sounds like somebody’s got a case of the tuesdays.";
            else if (weekDay == "wednesday")
                message = "Uh - oh. Sounds like somebody’s got a case of the wednesdays.";
            else if (weekDay == "thursday") 
            message = "Uh - oh. Sounds like somebody’s got a case of the thursdays.";
            else if (weekDay == "friday")
                message = "Uh - oh. Sounds like somebody’s got a case of the fridays.";
            else if (weekDay == "saturday") 
                message = "Uh - oh. Sounds like somebody’s got a case of the saturdays.";
            else if (weekDay == "sunday")
                message = "Uh - oh. Sounds like somebody’s got a case of the sundays.";

            return message;
        }

        [HttpGet, Route("BreakFast")]
        public string BreakFast(string input)
        {
            if (input.Equals("ägg", StringComparison.OrdinalIgnoreCase))
                return ($"Åh nej, du borde inte äta {input} till frukost!");
            else
                return ($"Ja, {input} är gott!");
        }

        [HttpGet, Route("QuadrateInput")]
        public int QuadrateInput(int number)
        {
            return number * number;
        }

        [HttpGet, Route("ListNumbers")]
        public List<int> ListNumbers(int number1, int number2)
        {
            List<int> list = new List<int>();

            for( int i = number1; number2 >= i; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [HttpGet, Route("BackgroundColor")]
        public IActionResult BackgroundColor(string colorOfChoice)
        {
            // Lärarens exempel
            string html = $"<body style='background-color:{colorOfChoice};'></body>";
            return Content(html, "text/html");
        }

        #region Default
        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
