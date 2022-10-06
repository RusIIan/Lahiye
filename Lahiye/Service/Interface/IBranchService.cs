﻿using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public interface IBranchService : IBankService<Branch>
    {
        public void HireEmployee(string brName, string empName);
        public void GetProfit();
        public void TransferMoney();
        public void TransferEmployee(string BranName, string EmpName);
    
}
}
