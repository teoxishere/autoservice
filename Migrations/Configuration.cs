namespace AutoService.Migrations
{
    using AutoService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoService.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoService.Models.Context context)
        {
            context.Users.AddOrUpdate(u => u.Username, new User
            {
                Role = Enums.RolesEnum.SuperAdmin,
                Username = "admin",
                Password = "admin"
            });
            context.SaveChanges();
        }
    }
}
