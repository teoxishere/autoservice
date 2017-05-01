namespace AutoService.Models
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
#if DEBUG
        public const string ConnectionStringName = "Context";
#endif
#if !DEBUG
        public const string ConnectionStringName = "ContextProd";
#endif

        public Context()
            : base("name=" + ConnectionStringName)
        {
        }

      
        public virtual DbSet<Car> Cars { get; set; }
        
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LogEntry> LogEntries { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
    }
}