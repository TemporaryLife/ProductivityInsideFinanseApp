using ProdInsideProj.Models;
using ProdInsideProj.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ProdInsideProj.ViewModels
{
    internal class HistoryPanelViewModel : INotifyPropertyChanged
    {
        private List<Operation> operationsToShowInHistory;

        public event PropertyChangedEventHandler PropertyChanged;
        public List<Operation> OperationsToShowInHistory
        {
            get
            {
                return operationsToShowInHistory;
            }
            set
            {
                operationsToShowInHistory = value;
                OnPropertyChanged();
            }
        }

        public HistoryPanelViewModel()
        {
            OperationsToShowInHistory = ProdInsideDbContext.GetLastOperations();
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
