using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;                                                                                        
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public interface IBranchService:IBankServicу<T> where T:BaseEntity
    {
        void HireEmployee();
        void GetProfit(int salary);
        void TransferMoney();
        void TransferEmployee();
    }

    
}
