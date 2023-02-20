using DatabaseAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public RoleType Role { get; set; } = RoleType.Student;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;

        // Used for Employer role
        public string CompanyName { get; set; } = String.Empty;

        // Used for Student role
        public string StudentNum { get; set; } = String.Empty;
        public string University { get; set; } = String.Empty;
        public string Program { get; set; } = String.Empty;
    }
}
