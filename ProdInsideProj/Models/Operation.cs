using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal OperationSum { get; set; }
        public string OperationType { get; set; }
        public string OperationCategory { get; set; }
        public string Comment { get; set; }

        //Foreign Key

        public int AccountId { get; set; }



    }
}
