using DatabaseAccess.Entities;
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
            ApplicationUser user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }

        public async Task UpdateUser(ApplicationUser updatedUser)
        {
            _context.Users.Update(updatedUser);
            _context.SaveChanges();
        }
    }
}
