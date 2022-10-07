using Lahiye.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public  interface IBankService<T> where T: BaseEntity
    { 
        public void Create();
        public void Delete();
        public void Update();
        public void Get();
        public void GetAllToConsole();
    }
}
