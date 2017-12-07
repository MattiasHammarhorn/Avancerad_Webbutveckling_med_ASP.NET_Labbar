using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_1.Controllers
{
    [Route("demo4")]
    public class Demo4ApiController : Controller
    {
        [HttpPost, Route("AddMeeting")]
        public IActionResult AddMeeting(Meeting meeting)
        {
            return Ok($"Du har angett mötet {meeting.Name} med agendan {meeting.Agenda}");
        }
    }
}
