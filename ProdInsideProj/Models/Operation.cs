using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Models
{
    public class Operation :INotifyPropertyChanged
    {

        private int operationSum;
        private string operationType;
        private string operationCategory;
        private string comment="123";
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public int OperationSum
        {
            get 
            {
                return operationSum;
            }
            set
            {
                operationSum = value;
                OnPropertyChanged();
            } 
        }

        public string OperationType
        {
            get
            {
                return operationType;
            }
            set
            {
                operationType = value;
                OnPropertyChanged();
            }
        }

        public string OperationCategory
        {
            get
            {
                return operationCategory;
            }
            set
            {
                operationCategory = value;
                OnPropertyChanged();
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /*public int AccountId { get; set; }*/



        //Foreign Key
        public Operation()
        {
            OperationDate = new DateTime().Date;
            
            
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
