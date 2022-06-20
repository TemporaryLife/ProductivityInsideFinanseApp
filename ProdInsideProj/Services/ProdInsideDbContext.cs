using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ProdInsideProj;



using ProdInsideProj.Models;

namespace ProdInsideProj.Services
{
    public class ProdInsideDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public string DbPath { get; }
        public ProdInsideDbContext()
        {
            var res = Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Filename=Test2.db");
    }
}
