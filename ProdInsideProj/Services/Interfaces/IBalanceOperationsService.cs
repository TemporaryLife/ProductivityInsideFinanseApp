using ProdInsideProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Services.Interfaces
{
    internal interface IBalanceOperationsService
    {
        Account UsingAccount { get; }
        double Income(Account usingAccount,bool isIncome,double sum);

    }
}
