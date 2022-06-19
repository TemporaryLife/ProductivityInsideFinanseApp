using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal AccountBalance { get; set; }

        public List<Operation> AccountOperations { get; set; }
    }
}
