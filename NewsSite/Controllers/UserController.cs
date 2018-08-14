using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NewsSite.Entities;
using NewsSite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsSite.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private NewsSiteDbContext newsSiteDbContext;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, NewsSiteDbContext newsSiteDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.newsSiteDbContext = newsSiteDbContext;
            newsSiteDbContext.Database.EnsureCreatedAsync();
        }

        [HttpGet, Route("seedDatabase")]
        async public Task<IActionResult> SeedDatabase()
        {
            foreach (ApplicationUser userToDelete in userManager.Users.ToList())
            {
                await userManager.DeleteAsync(userToDelete);
            }

            ApplicationUser userToCreate1 = new ApplicationUser() { UserName = "Adam", Email = "adam@gmail.com" };
            await userManager.CreateAsync(userToCreate1);
            await userManager.AddClaimAsync(userToCreate1, new Claim("NewsSiteRole", "Administrator"));
            await userManager.AddClaimAsync(userToCreate1, new Claim("CategoryPublisher", "Economy"));
            await userManager.AddClaimAsync(userToCreate1, new Claim("CategoryPublisher", "Sports"));
            await userManager.AddClaimAsync(userToCreate1, new Claim("CategoryPublisher", "Culture"));

            ApplicationUser userToCreate2 = new ApplicationUser() { UserName = "Peter", Email = "peter@gmail.com" };
            await userManager.CreateAsync(userToCreate2);
            await userManager.AddClaimAsync(userToCreate2, new Claim("NewsSiteRole", "Publisher"));
            await userManager.AddClaimAsync(userToCreate2, new Claim("CategoryPublisher", "Economy"));
            await userManager.AddClaimAsync(userToCreate2, new Claim("CategoryPublisher", "Sports"));

            ApplicationUser userToCreate3 = new ApplicationUser() { UserName = "Susan", Email = "susan@gmail.com"};
            await userManager.CreateAsync(userToCreate3);
            await userManager.AddClaimAsync(userToCreate3, new Claim("NewsSiteRole", "Subscriber"));
            await userManager.AddClaimAsync(userToCreate3, new Claim("Age", "48"));

            ApplicationUser userToCreate4 = new ApplicationUser() { UserName = "Viktor", Email = "viktor@gmail.com"};
            await userManager.CreateAsync(userToCreate4);
            await userManager.AddClaimAsync(userToCreate4, new Claim("NewsSiteRole", "Subscriber"));
            await userManager.AddClaimAsync(userToCreate4, new Claim("Age", "15"));

            ApplicationUser userToCreate5 = new ApplicationUser() { UserName = "Xerxes", Email = "xerxes@gmail.com" };
            await userManager.CreateAsync(userToCreate5);

            return Ok("");
        }

        [HttpGet, Route("login")]
        async public Task<IActionResult> Login(string email)
        {
            var userToLogin = await userManager.FindByEmailAsync(email);

            await signInManager.SignInAsync(userToLogin, true);
            return Ok("");
        }

        [HttpGet, Route("GetApplicationUserEmails")]
        public List<string> GetApplicationUserEmails()
        {
            List<string> applicationUserEmails = new List<string>();

            foreach (ApplicationUser applicationUser in userManager.Users.ToList())
            {
                applicationUserEmails.Add(applicationUser.Email.ToString());
            }

            return applicationUserEmails;
        }

        [HttpGet, Route("GetApplicationUsersWithClaims")]
        public async Task<IActionResult> GetApplicationUsersWithClaimsAsync()
        {
            List<ApplicationUser> applicationUserList = userManager.Users.ToList();

            List<UserClaims> userClaimsList = new List<UserClaims>();

            foreach (ApplicationUser user in applicationUserList)
            {
                var newUserClaim = new UserClaims();

                newUserClaim.ApplicationUser = user;
                newUserClaim.IdentityUserClaim = await userManager.GetClaimsAsync(user);

                userClaimsList.Add(newUserClaim);
            }

            return Ok(userClaimsList);
        }
    }
}
