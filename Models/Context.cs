namespace AutoService.Models
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Version> Versions { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Body> Bodies { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}