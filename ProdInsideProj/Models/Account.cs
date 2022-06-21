using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ProdInsideProj.Models
{
    public class Account : INotifyPropertyChanged
    {
        private int accountBalance;
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public int AccountBalance
        {
            get
            {
                return accountBalance;
            }
            set
            {
                accountBalance = value;
                OnPropertyChanged();
            }
        }
        public List<Operation> AccountOperations { get; set; }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override string ToString()
        {
            return AccountBalance + "$";
        }
    }
}