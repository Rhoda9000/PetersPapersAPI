using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetersPaper.Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Task> Tasks{ get; set; }


    }
}
