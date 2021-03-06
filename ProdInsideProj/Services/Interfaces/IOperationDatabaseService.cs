using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Services.Interfaces
{
    interface IOperationDatabaseService
    {
        RelayCommand AddCommand { get; }
        RelayCommand ResetCommand { get; }
    }
}
