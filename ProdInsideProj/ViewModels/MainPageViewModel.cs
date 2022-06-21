using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ProdInsideProj.ViewModels
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {

        private string activeType;
        private string errorMessage;
        private string successfulInputMessage;
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> activeCategoryList;

        public static List<string> IncomeCategories { get; set; } = new List<string>
        {
            "Зарплата",
            "Стипендия",
            "Дивиденды"
        };

        public static List<string> ConsumptionCategories { get; set; } = new List<string>
        {
            "Развлечения",
            "Еда",
            "Транспорт",
            "Здоровье"

        };

        public static List<string> TypeOfOperation { get; set; } = new List<string>
        {
            "Доход",
            "Расход"
        };

        public bool IsEnoughMoney { get; set; }
        public string ActiveType
        {
            get { return activeType; }
            set
            {
                activeType = value;
                OnPropertyChanged();

                if (value == "Доход")
                {
                    ActiveCategoryList = IncomeCategories;
                }
                else if (value == "Расход")
                {
                    ActiveCategoryList = ConsumptionCategories;
                }


            }
        }
        public List<string> ActiveCategoryList
        {
            get => activeCategoryList;

            set
            {
                activeCategoryList = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }
        public string SuccessfulInputMessage
        {
            get
            {
                return successfulInputMessage;
            }
            set
            {
                successfulInputMessage = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }






    }
}
