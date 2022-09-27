using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class BranchService:IBankService<Branch>,IBranchService
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
        public void Delete(string name)
        {
            Branch branch = _Bank.Datas.Find(d=>d.Name.ToLower().Trim()==name.ToLower().Trim());
            branch.SoftDelete = false;
        }

        public void Get(string entity)
        {
            Branch branch = _Bank.Datas.Find();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetProfit()
        {
            throw new NotImplementedException();
        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferMoney()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
