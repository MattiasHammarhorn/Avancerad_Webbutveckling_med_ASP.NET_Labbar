using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CustomerRegisterDatabase.Entities;
using Microsoft.Extensions.Configuration;
using CustomerRegisterDatabase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/demo")]
    public class DemoController : Controller
    {
        private DatabaseContext databaseContext;
        private IConfiguration configuration;
        private IHostingEnvironment env;
        private readonly MailConfiguration mailConfiguration;

        public DemoController(DatabaseContext databaseContext, IConfiguration configuration, IHostingEnvironment env, MailConfiguration mailConfiguration)
        {
            this.databaseContext = databaseContext;
            this.configuration = configuration;
            this.env = env;
            this.mailConfiguration = mailConfiguration;
        }

        [HttpGet, Route("Env")]
        public IActionResult Env()
        {
            return Ok(new object[]
            {
                env.IsEnvironment(env.ToString()),
                env.IsProduction(),
                env.ContentRootPath,
                env.ApplicationName,
                env.EnvironmentName,
                env.WebRootPath,
            });
        }

        [HttpGet]
        public IActionResult MailConfiguration()
        {
            return Ok(mailConfiguration);
        }
    }
}
