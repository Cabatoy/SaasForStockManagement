using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class FirstStepContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //server=.;database=FirstStep;trusted_connection=true;
            //Server =OURAL\\SQL2014; Database =FirstStep ; User Id =sa ; Password =sql2014 ; connection timeout = 60;  
         //   optionsBuilder.UseSqlServer(connectionString: @"Server=BERATOZMEN\SQLEXPRESS; Database=FirstStep; trusted_connection=true;");
            optionsBuilder.UseSqlServer(connectionString: @"Server =.\SQL2014; Database =FirstStep ; User Id =sa ; Password =sql2014 ; trusted_connection=true;");
        }

        public DbSet<Company> Company { get; set; }
        //public DbSet<Database> Databases { get; set; }
        //public DbSet<Licence> Licence { get; set; }
        //public DbSet<Local> Local { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<User> User { get; set; }
    }
}
