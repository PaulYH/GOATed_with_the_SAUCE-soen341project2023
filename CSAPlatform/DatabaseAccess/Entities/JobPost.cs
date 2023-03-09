using DatabaseAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = String.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public PostStatusType Status { get; set; } = PostStatusType.Open;
        public string Location { get; set; } = String.Empty;
        public JobType JobType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public string Description { get; set; } = String.Empty;

        //Database Relationships
        public ApplicationUser User { get; set; } = null!;
        public ICollection<JobApplication>? JobApplications { get; set; }
    }
}
