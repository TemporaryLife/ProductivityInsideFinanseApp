using ProdInsideProj.Models;
using ProdInsideProj.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Services
{
    public class BalanceOperationsService : IBalanceOperationsService
    {
        public Account UsingAccount { get; }

        public BalanceOperationsService()
        {
            UsingAccount = ProdInsideDbContext.GetOrCreateAccount();
        }

        public double Income(Account usingAccount, bool isIncome, double sum)
        {
            if (isIncome)
            {
                return usingAccount.AccountBalance += sum;
            }
            if (usingAccount.AccountBalance < sum)
            {
                return usingAccount.AccountBalance;
            }
            return usingAccount.AccountBalance -= sum;

        }
    }
}
