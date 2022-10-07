    using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.DataBase
{
    public class Bank_G<T>
    {
        public List<T> Datas;
        public Bank_G()
        {
            Datas = new List<T>();
        }
    }
}
