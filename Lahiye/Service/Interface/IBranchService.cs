using Lahiye.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public  interface IBranchService:IBankService<Branch>
    {
        void HireEmployee();
        void GetProfit(Branch entity);
        void TransferMoney();
        void TransferEmployee();
    }
}
