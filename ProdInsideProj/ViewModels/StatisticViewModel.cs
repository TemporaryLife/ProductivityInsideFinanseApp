using ProdInsideProj.Models;
using ProdInsideProj.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace ProdInsideProj.ViewModels
{
    internal class StatisticViewModel : INotifyPropertyChanged
    {
        private int spendedForTimePeriod;
        private int receivedForTimePeriod;
        private int spendedForHealth;
        private int spendedForTransport;
        private int spendedForEnjoyment;
        private int spendedForFood;
        private int receivedBySalary;
        private int receivedByStipend;
        private int receivedByDividends;
        private string periodToCheck;
        private List<string> timePeriodList;

        public static List<Operation> OperationsForRequiredPeriod { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> TimePeriodList
        {
            get
            {
                return timePeriodList;
            }
            set
            {
                timePeriodList = value;
                OnPropertyChanged();
            }
        }

        public int SpendedForTimePeriod
        {
            get
            {
                return spendedForTimePeriod;
            }
            set
            {
                spendedForTimePeriod = value;
                OnPropertyChanged();
            }
        }

        public int ReceivedForTimePeriod
        {
            get
            {
                return receivedForTimePeriod;
            }

            set
            {
                receivedForTimePeriod = value;
                OnPropertyChanged();
            }
        }

        public string PeriodToCheck
        {
            get => periodToCheck;

            set
            {
                periodToCheck = value;
                OnPropertyChanged();
                SpendedForTimePeriod = GetMoneyChangesForPeriod(periodToCheck, false);
                ReceivedForTimePeriod = GetMoneyChangesForPeriod(periodToCheck, true);
                ChangeAllCategoriesToShow();

            }
        }

        public int SpendedForHealth
        {
            get => spendedForHealth;

            set
            {
                spendedForHealth = value;
                OnPropertyChanged();
            }
        }

        public int SpendedForTransport
        {
            get => spendedForTransport;

            set
            {
                spendedForTransport = value;
                OnPropertyChanged();
            }
        }

        public int SpendedForEnjoyment
        {
            get => spendedForEnjoyment;

            set
            {
                spendedForEnjoyment = value;
                OnPropertyChanged();
            }
        }

        public int SpendedForFood
        {
            get => spendedForFood;

            set
            {
                spendedForFood = value;
                OnPropertyChanged();
            }
        }

        public int ReceivedBySalary
        {
            get => receivedBySalary;

            set
            {
                receivedBySalary = value;
                OnPropertyChanged();
            }
        }

        public int ReceivedByStipend
        {
            get => receivedByStipend;

            set
            {
                receivedByStipend = value;
                OnPropertyChanged();
            }
        }

        public int ReceivedByDividends
        {
            get => receivedByDividends;

            set
            {
                receivedByDividends = value;
                OnPropertyChanged();
            }
        }

        public StatisticViewModel()
        {
            TimePeriodList = new List<string>
            {
                "День",
                "Неделя",
                "Месяц"
            };

            periodToCheck = TimePeriodList[0];
            SpendedForTimePeriod = GetMoneyChangesForPeriod(periodToCheck, false);
            ReceivedForTimePeriod = GetMoneyChangesForPeriod(periodToCheck, true);
            ChangeAllCategoriesToShow();
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        public static int GetMoneyChangesForPeriod(string timePeriod, bool isIncome)    // using required time period takes DB data to show it
        {
            string operationType = isIncome ? "Доход" : "Расход";
            int moneyChanges = 0;
            List<Operation> requiredOperations;

            if (timePeriod == "День")
            {
                OperationsForRequiredPeriod = ProdInsideDbContext.GetOperationsForSomePeriod(1);
            }
            else if (timePeriod == "Неделя")
            {
                OperationsForRequiredPeriod = ProdInsideDbContext.GetOperationsForSomePeriod(7);
            }
            else if (timePeriod == "Месяц")
            {
                OperationsForRequiredPeriod = ProdInsideDbContext.GetOperationsForSomePeriod(30);
            }
            requiredOperations = OperationsForRequiredPeriod.Where(x => x.OperationType == operationType).ToList();
            moneyChanges = requiredOperations.Sum(x => x.OperationSum);
            return moneyChanges;
        }

        public void ChangeAllCategoriesToShow()        // Taking operation sums by categories
        {
            ReceivedByDividends = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Дивиденды").Sum(x => x.OperationSum);
            ReceivedBySalary = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Зарплата").Sum(x => x.OperationSum);
            ReceivedByStipend = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Стипендия").Sum(x => x.OperationSum);
            SpendedForEnjoyment = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Развлечения").Sum(x => x.OperationSum);
            SpendedForFood = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Еда").Sum(x => x.OperationSum);
            SpendedForHealth = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Здоровье").Sum(x => x.OperationSum);
            SpendedForTransport = OperationsForRequiredPeriod.Where(x => x.OperationCategory == "Транспорт").Sum(x => x.OperationSum);
        }
    }
}
