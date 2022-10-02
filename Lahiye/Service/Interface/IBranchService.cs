using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public  interface IBranchService:IBankService<Branch>
    {
        void HireEmployee(Branch branch);
        void GetProfit(Branch entity);
        void TransferMoney();
        void TransferEmployee(Branch branch);
    }
}
