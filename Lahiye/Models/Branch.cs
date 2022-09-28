using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Models
{
    public class Branch:BaseEntity
    {
        //Filial
        public decimal Budget { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set;  }
        public Branch(string name,decimal budget,string address)
        {
            this.Name = name;
            this.Budget = budget;
            this.Address = address;
            this.SoftDelete = false;
            this.Employees = new List<Employee>();
        }
    }
}
