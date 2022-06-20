using GalaSoft.MvvmLight.Command;
using ProdInsideProj.Models;
using ProdInsideProj.Services.Interfaces;
using ProdInsideProj.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ProdInsideProj.Services
{
    internal class OperationDatabaseService : IOperationDatabaseService
    {

        public MainPageViewModel viewModel { get; set; }
        public List<string> ActiveTypeOfOperation { get; set; }       
        public Operation NewOperation { get; set; }

        public BalanceOperationsService balanceOperationsService { get; set; }
        public Account usingAccount { get; set; }
        private RelayCommand addCommand { get; set; }
        private RelayCommand resetCommand { get; set; }





        public OperationDatabaseService()
        {
            NewOperation = new Operation();
            ActiveTypeOfOperation = new List<string>();
            viewModel = new MainPageViewModel();
            balanceOperationsService = new BalanceOperationsService();
            usingAccount = balanceOperationsService.UsingAccount;
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(() =>
                    {
                        
                        using (var db = new ProdInsideDbContext())
                        {
                            var newOper = new Operation
                            {
                                OperationSum = NewOperation.OperationSum,
                                OperationCategory = NewOperation.OperationCategory,
                                OperationType=viewModel.ActiveType,
                                Comment = NewOperation.Comment,                              
                            };

                            if (viewModel.ActiveType == "Доход")
                            {
                                usingAccount.AccountBalance = balanceOperationsService.Income(usingAccount, true, NewOperation.OperationSum);

                            }
                            else
                            {
                                usingAccount.AccountBalance = balanceOperationsService.Income(usingAccount, false, NewOperation.OperationSum);
                            }

                            db.Operations.Add(newOper);
                            db.Update(usingAccount);
                            db.SaveChanges();
                        }
                        
                    }));
            }
        }

        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                    (resetCommand = new RelayCommand(() =>
                    {
                        NewOperation.OperationSum = 0;
                        viewModel.ActiveType = "";
                        NewOperation.OperationCategory = "";
                        NewOperation.Comment = "";
                    }
                    ));
            }
        }

    }
}
