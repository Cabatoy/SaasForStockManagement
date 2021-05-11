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
        public FirstStepContext ()
	{

	}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //server=.;database=FirstStep;trusted_connection=true;
            //Server =OURAL\\SQL2014; Database =FirstStep ; User Id =sa ; Password =sql2014 ; connection timeout = 60;  
            // optionsBuilder.UseSqlServer(connectionString: @"Server=BERATOZMEN\SQLEXPRESS; Database=FirstStep; trusted_connection=true;");
            optionsBuilder.UseSqlServer(connectionString: @"Server =.\SQL2014; Database =FirstStep ; User Id =sa ; Password =sql2014 ; trusted_connection=true;");
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyOperationClaim> CompanyOperationClaim { get; set; }
        public DbSet<CompanyUserOperationClaim> CompanyUserOperationClaim { get; set; }
        public DbSet<CompanyUser> CompanyUser { get; set; }
        public DbSet<CompanyLocal> CompanyLocal { get; set; }

    }
}
