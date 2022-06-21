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

        public int Income(Account usingAccount, bool isIncome, int sum) // Changing balance if there are enough money
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
