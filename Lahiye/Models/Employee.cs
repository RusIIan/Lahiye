using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Models
{
    public  class Employee:BaseEntity
    {
        

         public string Surname { get; set; }
         public decimal Salary { get; set; }
         public string Professin { get; set; }
         public Branch branch { get; set; }

       /* public Employee(string name, string surname, decimal salary,string professin)
        {
            this.Name = name;
            this.Surname = surname;
            this.Salary = salary;
            this.SoftDelete = false;
            this.Professin = professin;
        }*/
    }
}
