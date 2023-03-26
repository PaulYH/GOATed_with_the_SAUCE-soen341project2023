using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class ApplicationUserService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserById(string userId)
        {
            ApplicationUser user = _context.Users.Include(user => user.JobApplications).Include(user => user.JobPosts).FirstOrDefault(x => x.Id == userId);
            return user;
        }

        public async Task UpdateUser(ApplicationUser updatedUser)
        {
            _context.Users.Update(updatedUser);
            _context.SaveChanges();
        }

        public ApplicationUser UploadPdf(string userId, byte[] pdf)
        {
            _context.Users.FirstOrDefault(x => x.Id == userId).Attachment = pdf;
            _context.SaveChanges();
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public void DeletePdf(string userId)
        {
            _context.Users.FirstOrDefault(x => x.Id == userId).Attachment = null;
            _context.SaveChanges();
            return;
        }
    }
}
