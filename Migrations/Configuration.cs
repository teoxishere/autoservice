namespace AutoService.Migrations
{
    using AutoService.Models;
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoService.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Context context)
        {
            var user = new User
            {
                IsAdmin = true,
                Username = "admin",
                Password = "admin"
            };
            context.Users.AddOrUpdate(u => u.Username, user);
            context.SaveChanges();

            var makeBmw = new Make
            {
                Name = "BMW"
            };
            var makeMercedes = new Make
            {
                Name = "Mercedes-Benz"
            };
            context.Makes.AddOrUpdate(m => m.Name, makeBmw, makeMercedes);
            context.SaveChanges();

            var modelBmwM3 = new Model
            {
                MakeId = makeBmw.Id,
                Name = "M3"
            };
            var modelBmwM4 = new Model
            {
                MakeId = makeBmw.Id,
                Name = "M4"
            };
            var modelMercedesCls = new Model
            {
                MakeId = makeMercedes.Id,
                Name = "CLS"
            };
            var modelMercedesS = new Model
            {
                MakeId = makeMercedes.Id,
                Name = "S"
            };
            context.Models.AddOrUpdate(m => new { m.MakeId, m.Name }, modelBmwM3, modelBmwM4, modelMercedesCls, modelMercedesS);
            context.SaveChanges();

            var bodyBerlina = new Body
            {
                Name = "Berlina"
            };

            var bodyCabrio = new Body
            {
                Name = "Cabrio"
            };

            context.Bodies.AddOrUpdate(b => b.Name, bodyBerlina, bodyCabrio);
            context.SaveChanges();

            var engine3LBmw = new Engine {
                Fuel = "BENZINA",
                Power = 310,
                Cc = 3000,
                Name = "Motor 3L BMW"
            };

            var engine3LMercedes = new Engine
            {
                Fuel = "BENZINA",
                Power = 300,
                Cc = 3000,
                Name = "Motor 3L Mercedes"
            };

            context.Engines.AddOrUpdate(e => new { e.Name, e.Power, e.Cc, e.Fuel }, engine3LBmw, engine3LMercedes);
            context.SaveChanges();

            var bmwM32000Cabrio = new Models.Version
            {
                BodyId = bodyCabrio.Id,
                EngineId = engine3LBmw.Id,
                ModelId = modelBmwM3.Id,
                Year = 2000,
                Name = "M3 2000 Cabrio"
            };

            var bmwM42001Cabrio = new Models.Version
            {
                BodyId = bodyCabrio.Id,
                EngineId = engine3LBmw.Id,
                ModelId = modelBmwM4.Id,
                Year = 2001,
                Name = "M4 2001 Cabrio"
            };

            var mercedesS2015Berlina = new Models.Version
            {
                BodyId = bodyBerlina.Id,
                EngineId = engine3LMercedes.Id,
                ModelId = modelMercedesS.Id,
                Year = 2015,
                Name = "S 2015"
            };

            var mercedesCls2015Berlina = new Models.Version
            {
                BodyId = bodyBerlina.Id,
                EngineId = engine3LMercedes.Id,
                ModelId = modelMercedesCls.Id,
                Year = 2015,
                Name = "CLS 2015"
            };

            context.Versions.AddOrUpdate(v => new { v.ModelId, v.Year, v.BodyId, v.EngineId }, mercedesCls2015Berlina, mercedesS2015Berlina, bmwM32000Cabrio, bmwM42001Cabrio);
            context.SaveChanges();
        }
    }
}
