using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Models
{
    public class Branch:BaseEntity
    {
        //Filial
        private static List<Branch> branches = new List<Branch>();
        public decimal Budget { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set;  }
        public Branch()
        {
            branches = new List<Branch>();
        }
        public static List<Branch> AllBranch
        {
            get
            {
                return branches;
            }
        }
    }
}
