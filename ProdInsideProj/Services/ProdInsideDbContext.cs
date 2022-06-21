using Microsoft.EntityFrameworkCore;
using ProdInsideProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        => options.UseSqlite($"Filename=ProductivityInsideDataBase.db");

        public static Account GetOrCreateAccount()                                  // If there are no account, create it
        {                                                                           // If it's created, takes it
            using (var db = new ProdInsideDbContext())
            {
                Account account;
                if (db.Accounts.Count() == 0)
                {
                    account = new Account();
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
                else
                {
                    account = db.Accounts.ToArray()[0];
                }

                return account;
            }
        }

        public static List<Operation> GetLastOperations()                               // Takes DB context to show it in app
        {
            var list = new List<Operation>();
            using (var db = new ProdInsideDbContext())
            {
                list = db.Operations.OrderByDescending(x => x.OperationDate).Take(11).ToList();
            }
            return list;
        }

        public static List<Operation> GetOperationsForSomePeriod(int timePeriodDays)      // Takes DB context using required time period to see stat
        {
            var list = new List<Operation>();

            using (var db = new ProdInsideDbContext())
            {
                list = db.Operations.Where(x => x.OperationDate.Day >= DateTime.Now.Day + 30 * (DateTime.Now.Month - x.OperationDate.Month) - timePeriodDays).ToList();
            }
            return list;
        }


    }
}
