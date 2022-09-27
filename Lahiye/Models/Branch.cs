using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Models
{
    public class Branch:BaseEntity
    {
        //Filial
        public string Name { get; set; }
        public double Budget { get; set; }
        public string Address { get; set; }
        public List<Employee> employees { get; set;  }
    }
}
