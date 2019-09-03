using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intermediate_Test2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Balance { get; set; }
        public bool HasWithdrawThisYear { get; set; }
    }
}
