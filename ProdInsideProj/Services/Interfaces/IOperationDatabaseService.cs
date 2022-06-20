using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Services.Interfaces
{
    interface IOperationDatabaseService
    {
        bool AddOperation();
        bool DeleteOperation();
        bool ChangeOperationInfo();


    }
}
