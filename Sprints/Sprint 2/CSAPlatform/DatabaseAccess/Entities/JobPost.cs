using DatabaseAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public PostStatusType Status { get; set; } = PostStatusType.Open;
        public string Location { get; set; } = null!;
        public JobType JobType { get; set; }
        public decimal Salary { get; set; }

    }
}
