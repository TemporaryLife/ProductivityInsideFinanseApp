using ProdInsideProj.Models;
using ProdInsideProj.Services.Interfaces;


namespace ProdInsideProj.Services
{
    public sealed class BalanceOperationsService : IBalanceOperationsService
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
