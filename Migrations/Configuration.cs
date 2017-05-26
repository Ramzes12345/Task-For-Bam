namespace Task1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    internal sealed class Configuration : DbMigrationsConfiguration<Task1.Models.ApplicationDbContext>
    {
        public Configuration()
        { 
            AutomaticMigrationsEnabled = false;
            ContextKey = "Task1.Models.ApplicationDbContext";
        }

        protected override void Seed(Task1.Models.ApplicationDbContext context)
        {
           
        }
    }
}
