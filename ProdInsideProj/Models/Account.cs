using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Models
{
    public class Account : INotifyPropertyChanged
    {
        private double accountBalance;

        public int Id { get; set; }
        public double AccountBalance 
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

        public event PropertyChangedEventHandler PropertyChanged;


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
