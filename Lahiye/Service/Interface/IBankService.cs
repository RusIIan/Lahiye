using Lahiye.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Service.Interface
{
    public  interface IBankService<T> where T: BaseEntity
    { 
        void Create(T entity);
        void Delete(string name);
        void Update();
        void Get(string entity);
        void GetAll();
    }
}
