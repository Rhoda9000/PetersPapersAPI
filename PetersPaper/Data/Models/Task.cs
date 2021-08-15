using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetersPaper.Data.Models
{
    public class Task
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }

    }
}
