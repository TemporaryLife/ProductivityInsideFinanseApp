using GalaSoft.MvvmLight.Command;
using ProdInsideProj.Models;
using ProdInsideProj.Models.Messages;
using ProdInsideProj.Services.Interfaces;
using ProdInsideProj.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProdInsideProj.Services
{
    internal class OperationDatabaseService : IOperationDatabaseService
    {

        public MainPageViewModel viewModel { get; set; }
        public HistoryPanelViewModel historyPanelViewModel { get; set; }
        public StatisticViewModel statisticViewModel { get; set; }
        public List<string> ActiveTypeOfOperation { get; set; }
        public Operation NewOperation { get; set; }
        public BalanceOperationsService balanceOperationsService { get; set; }
        public Account usingAccount { get; set; }
        private RelayCommand addCommand { get; set; }
        private RelayCommand resetCommand { get; set; }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(async () =>
                    {
                        if (NewOperation.OperationSum <= 1000000 && NewOperation.OperationSum > 0 && NewOperation.OperationCategory != null && viewModel.ActiveType != null)
                        {
                            using (var db = new ProdInsideDbContext())
                            {
                                var newOper = new Operation
                                {
                                    OperationSum = NewOperation.OperationSum,
                                    OperationCategory = NewOperation.OperationCategory,
                                    OperationType = viewModel.ActiveType,
                                    Comment = NewOperation.Comment,
                                };

                                if (viewModel.ActiveType == "Доход" || (viewModel.ActiveType == "Расход" && usingAccount.AccountBalance >= NewOperation.OperationSum))
                                {
                                    if (viewModel.ActiveType == "Доход")
                                    {
                                        usingAccount.AccountBalance = balanceOperationsService.Income(usingAccount, true, NewOperation.OperationSum);
                                    }
                                    else if (viewModel.ActiveType == "Расход")
                                    {
                                        usingAccount.AccountBalance = balanceOperationsService.Income(usingAccount, false, NewOperation.OperationSum);
                                    }

                                    db.Operations.Add(newOper);
                                    db.Update(usingAccount);
                                    ResetSettings();
                                    db.SaveChanges();
                                }
                            }

                            statisticViewModel.ReceivedForTimePeriod = StatisticViewModel.GetMoneyChangesForPeriod(statisticViewModel.PeriodToCheck, true);
                            statisticViewModel.SpendedForTimePeriod = StatisticViewModel.GetMoneyChangesForPeriod(statisticViewModel.PeriodToCheck, false);
                            historyPanelViewModel.OperationsToShowInHistory = ProdInsideDbContext.GetLastOperations();
                            statisticViewModel.ChangeAllCategoriesToShow();
                            await TemporaryShowMessageAsync(1500);
                        }
                        else
                        {
                            viewModel.ErrorMessage = Messages.InvalidSumOrNullTypeCategoryMessage;
                        }

                    }));
            }
        }
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ?? (resetCommand = new RelayCommand(() => ResetSettings()));
            }
        }

        public OperationDatabaseService()
        {
            NewOperation = new Operation();
            ActiveTypeOfOperation = new List<string>();
            viewModel = new MainPageViewModel();
            historyPanelViewModel = new HistoryPanelViewModel();
            statisticViewModel = new StatisticViewModel();
            balanceOperationsService = new BalanceOperationsService();
            usingAccount = balanceOperationsService.UsingAccount;
        }

        
        private void ResetSettings()
        {
            NewOperation.OperationSum = 0;
            viewModel.ActiveType = "";
            NewOperation.OperationCategory = "";
            NewOperation.Comment = "";
            viewModel.ErrorMessage = "";
        }

        private async Task TemporaryShowMessageAsync(int delayMilliSeconds)
        {
            viewModel.SuccessfulInputMessage = Messages.SuccessfulInputMessage;
            await Task.Delay(delayMilliSeconds);
            viewModel.SuccessfulInputMessage = "";

        }


    }
}
