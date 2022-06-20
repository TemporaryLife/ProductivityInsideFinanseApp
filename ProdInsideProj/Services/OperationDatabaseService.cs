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
    internal class OperationDatabaseService 
    {

        public MainPageViewModel viewModel { get; set; } = new MainPageViewModel();

        public Operation NewOperation { get; set; } = new Operation();

        private RelayCommand addCommand { get; set; }
        private RelayCommand resetCommand { get; set; }

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
                                Comment = NewOperation.Comment,
                                OperationCategory = NewOperation.OperationCategory
                            };

                            db.Operations.Add(newOper);

                            var a = db.Operations.Count();
                            var b = db.Operations;
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
                        NewOperation.Comment = "";
                        NewOperation.OperationCategory = "";
                    }
                    ));
            }
        }
        

        public bool ChangeOperationInfo()
        {
            throw new NotImplementedException();
        }

        public bool DeleteOperation()
        {
            throw new NotImplementedException();
        }
    }
}
