using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class JobApplicationService
    {
        public readonly ApplicationDbContext _context;

        public JobApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobApplication>> GetJobApplicationsByUser(string userId)
        {
            var appList = _context.JobApplications.Where(x => x.User.Id == userId).ToList();
            return appList;
        }

        public async Task<List<JobApplication>> GetJobApplicationsByPost(int postId)
        {
            var appList = _context.JobApplications.Where(x => x.JobPost.Id == postId).ToList();
            return appList;
        }

        public string CreateApplication(JobApplication newApp)
        {
            _context.JobApplications.Add(newApp);
            _context.SaveChanges();
            return "New application created successfully";
        }

        public string UpdateApplication(JobApplication updatedApp)
        {
            _context.JobApplications.Update(updatedApp);
            _context.SaveChanges();
            return "Application updated successfully";
        }

        public string DeleteApplication(JobApplication deletedApp)
        {
            _context.JobApplications.Remove(deletedApp);
            _context.SaveChanges();
            return "Application has been deleted";
        }
    }
}
