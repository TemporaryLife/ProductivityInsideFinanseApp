using ProdInsideProj.Models;

namespace ProdInsideProj.Services.Interfaces
{
    internal interface IBalanceOperationsService
    {
        Account UsingAccount { get; }
        int Income(Account usingAccount, bool isIncome, int sum);
    }
}
