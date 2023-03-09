using DatabaseAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public AppStatusType Status { get; set; } = AppStatusType.Submitted;

        // Database Relationships
        public ApplicationUser User { get; set; } = null!;
        public JobPost JobPost { get; set; } = null!;
    }
}
