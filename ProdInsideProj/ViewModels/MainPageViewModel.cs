using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.ViewModels
{
    internal class MainPageViewModel
    {
        public List<string> IncomeCategories { get; set; } = new List<string>
        {
            "Зарплата",
            "Стипендия",
            "Дивиденды"
        };

        public List<string> ConsumptionCategories { get; set; } = new List<string>
        {
            "Развлечение",
            "Еда",
            "Транспорт",
            "Здоровье"
            
        };

        public List<string> TypeOfOperation { get; set; } = new List<string>
        {
            "Доход",
            "Расход"
        };
    }
}
