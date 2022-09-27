using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.DataBase
{
    public class Generic_Bank<T>
    {
        public List<T> Datas = new List<T>();
        public Generic_Bank()
        {
            Datas = new List<T>();
        }
    }
}
