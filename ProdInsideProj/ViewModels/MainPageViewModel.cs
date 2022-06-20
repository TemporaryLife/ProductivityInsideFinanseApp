using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.ViewModels
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {

        private string activeType;

        private List<string> activeCategoryList;

        public event PropertyChangedEventHandler PropertyChanged;

        public static List<string> IncomeCategories { get; set; } = new List<string>
        {
            "Зарплата",
            "Стипендия",
            "Дивиденды"
        };

        public static List<string> ConsumptionCategories { get; set; } = new List<string>
        {
            "Развлечение",
            "Еда",
            "Транспорт",
            "Здоровье"

        };

        public static List<string> TypeOfOperation { get; set; } = new List<string>
        {
            "Доход",
            "Расход"
        };

        public List<string> ActiveCategoryList 
        { 
            get => activeCategoryList; 

            set 
            {
                activeCategoryList = value;
                OnPropertyChanged();
            } 
        }
        
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

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }






    }
}
