using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace NewsSite.Controllers
{
    [Route("check")]
    public class CheckController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CheckController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [AllowAnonymous]
        [HttpGet, Route("CanSeeOpenNews")]
        public IActionResult CanSeeOpenNews()
        {
            return Ok("");
        }

        [Authorize(Policy = "SubscriberRights")]
        [HttpGet, Route("CanSeeHiddenNews")]
        public IActionResult CanSeeHiddenNews()
        {
            return Ok("");
        }
        
        [Authorize(Policy = "ViewRights")]
        [HttpGet, Route("CanSeeHiddenNewsAndIsOver20YearsOld")]
        public IActionResult CanSeeHiddenNewsAndIsOver20YearsOld()
        {
            return Ok("");
        }

        [Authorize(Policy = "PublisherRights")]
        [HttpGet, Route("CanPublishNews")]
        public IActionResult CanPublishNews()
        {
            return Ok("");
        }

        [Authorize(Policy = "EconomyPublisherRights")]
        [HttpGet, Route("CanPublishEconomyNews")]
        public IActionResult CanPublishEconomyNews()
        {
            return Ok("");
        }

        [Authorize(Policy = "SportsPublisherRights")]
        [HttpGet, Route("CanPublishSportsNews")]
        public IActionResult CanPublishSportsNews()
        {
            return Ok("");
        }

        [Authorize(Policy = "CulturePublisherRights")]
        [HttpGet, Route("CanPublishCultureNews")]
        public IActionResult CanPublishCultureNews()
        {
            return Ok("");
        }
    }
}
