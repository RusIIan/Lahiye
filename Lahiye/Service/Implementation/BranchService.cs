using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class BranchService
    {
        private Generic_Bank<Branch> _Bank;

        public BranchService()
        {
            _Bank = new Generic_Bank<Branch>();
        }
        public void Create(Branch branch) 
        {
            _Bank.Datas.Add(branch);
        }
        public void Delete()
        {
            Branch branch;
        }
    }
}
