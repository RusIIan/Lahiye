using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.Models
{
    public abstract class BaseEntity
    {
        public string Name { get; set; }
        public bool SoftDelete { get; set; }

    }
}
