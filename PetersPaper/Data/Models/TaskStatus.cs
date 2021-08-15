using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetersPaper.Data.Models
{
    public class TaskStatus
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Task Task { get; set; }

    }
}
