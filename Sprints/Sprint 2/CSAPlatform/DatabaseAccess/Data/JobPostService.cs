﻿using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class JobPostService
    {
        private readonly ApplicationDbContext _context;

        public JobPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<JobPost> GetAllJobPosts()
        {
            var jobList = _context.JobPosts.ToList();
            return jobList;
        }

        public List<JobPost> GetUserJobPosts(string userId)
        {
            var jobList = _context.JobPosts.Where(x => x.User.Id == userId).ToList();
            return jobList;

        }

        public JobPost GetJobPostGetById(int id)
        {
            JobPost job = _context.JobPosts.FirstOrDefault(x => x.Id == id);
            return job;

        }

        public string CreateJob(JobPost newPost)
        {
            _context.JobPosts.Add(newPost);
            _context.SaveChanges();
            return "New Job created successfully";
        }

        public string UpdateJob(JobPost updatedPost)
        {
            _context.JobPosts.Update(updatedPost);
            _context.SaveChanges();
            return "Job post updated successfully";
        }

        public string DeleteJob(JobPost deletedPost)
        {
            _context.JobPosts.Remove(deletedPost);
            _context.SaveChanges();
            return "Job post has been deleted";
        }



    }
}
