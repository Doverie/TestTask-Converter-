using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgramDataLayer.DbModel;

namespace TestProgramDataLayer
{
    class DBContext : DbContext
    {
        public DBContext()
            : base("DBConnection")
        { }

        public DbSet<Broker> Broker { get; set; }
        public DbSet<TargetFile> TargetFile { get; set; }
        public DbSet<SourceFile> SourceFile { get; set; }
    }
}
