using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Task1.Models;

namespace Task1.Controllers
{
 
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            initlogins();
            return View();
        }
        [Authorize(Roles = "FullAdmin")]
        public ActionResult Usermanagement()
        {

            return View();
        }
        [Authorize(Roles = "FullAdmin,Users")]
        public ActionResult Welcomepage()
        {

            return View();
        }

        public void initlogins()
        {
            var context = new ApplicationDbContext();
            using (var userStore = new UserStore<ApplicationUser>(context))
            using (var userManager = new UserManager<ApplicationUser>(userStore))
            {
                if (!context.Roles.Any(r => r.Name == "FullAdmin"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "FullAdmin" };

                    manager.Create(role);
                }
                if (!context.Users.Any(u => u.UserName == "MasterUser"))
                {
                    var user = new ApplicationUser { UserName = "MasterUser", Email = "MasterUser@fake.com", LockoutEnabled = false };
                    var createTask = userManager.CreateAsync(user, "111111");
                    var result = createTask.Result;
                    userManager.AddToRole(user.Id, "FullAdmin");
                }
                if (!context.Roles.Any(r => r.Name == "Users"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Users" };

                    manager.Create(role);
                }
                if (!context.Users.Any(u => u.UserName == "User1"))
                {
                    var user = new ApplicationUser { UserName = "User1", Email = "User1@fake.com", LockoutEnabled = false };
                    var createTask = userManager.CreateAsync(user, "111111");
                    var result = createTask.Result;
                    userManager.AddToRole(user.Id, "Users");
                }
                if (!context.Users.Any(u => u.UserName == "User2"))
                {
                    var user = new ApplicationUser { UserName = "User2", Email = "User2@fake.com", LockoutEnabled = false };
                    var createTask = userManager.CreateAsync(user, "111111");
                    var result = createTask.Result;
                    userManager.AddToRole(user.Id, "Users");
                }
            }
        }
      
    }
}