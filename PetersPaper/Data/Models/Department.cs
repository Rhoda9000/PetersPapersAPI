using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetersPaper.Data.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }

    }
}
