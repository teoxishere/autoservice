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

      
        public virtual DbSet<Car> Cars { get; set; }
        
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LogEntry> LogEntries { get; set; }
    }
}