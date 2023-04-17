using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class JobApplicationServiceTests : IDisposable
    {
        private static DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "JobApplicationServiceTests").Options;

        ApplicationDbContext context;
        JobApplicationService service;

        public JobApplicationServiceTests()
        {
            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            service = new JobApplicationService(context);

            SeedDatabase();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetJobApplicationByIdTest_ShouldReturnJobApplication_MatchingId()
        {
            //Arrange
            var Id = 2;

            //Act
            JobApplication selectedApp = await service.GetJobApplicationById(Id);

            //Assert
            Assert.Equal(Id, selectedApp.Id);
        }
        [Fact]
        public async Task GetJobApplicationsByUserTest_ShouldReturnJobApplicationsList_MatchingCount()
        {
            //Arrange
            var count = context.JobApplications.Count();

            //Act
            List<JobApplication> applications = await service.GetJobApplicationsByUser("TestUser");

            //Assert
            Assert.Equal(count, applications.Count);
        }

        [Fact]
        public async Task GetJobApplicationsByPostTest_ShouldReturnJobApplicationsList_MatchingCount()
        {
            //Arrange
            var count = context.JobApplications.Count();

            //Act
            List<JobApplication> applications = await service.GetJobApplicationsByPost(1);

            //Assert
            Assert.Equal(count, applications.Count);
        }
        [Fact]
        public void CreateApplicationTest_ShouldIncrementCountAndReturnString()
        {
            //Arrange
            var count = context.JobApplications.Count();
            var expectedMessage = "New application created successfully";

            //Act
            var returnedMessage = service.CreateApplication(new JobApplication() { Id = count + 1 });

            //Assert
            Assert.Equal(count + 1, context.JobApplications.Count());
            Assert.Equal(expectedMessage, returnedMessage);
        }

        [Fact]
        public void UpdateApplicationTest_ShouldDecrementCountAndReturnString()
        {
            //Arrange
            var newStatus = AppStatusType.Selected;
            var expectedMessage = "Application updated successfully";
            JobApplication jobApp = context.JobApplications.First();
            jobApp.Status = AppStatusType.Selected;
            //Act
            var returnedMessage = service.UpdateApplication(jobApp);

            //Assert
            Assert.Equal(newStatus, context.JobApplications.First().Status);
            Assert.Equal(expectedMessage, returnedMessage);
        }

        [Fact]
        public void DeleteApplicationTest_ShouldDecrementCountAndReturnString()
        {
            //Arrange
            var count = context.JobApplications.Count();
            var expectedMessage = "Application has been deleted";

            //Act
            var returnedMessage = service.DeleteApplication(context.JobApplications.First());

            //Assert
            Assert.Equal(count - 1, context.JobApplications.Count());
            Assert.Equal(expectedMessage, returnedMessage);
        }


        private void SeedDatabase()
        {
            var jobApplications = new List<JobApplication>()
            {
                new JobApplication()
                {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    Status = AppStatusType.Submitted
                },
                new JobApplication()
                {
                    Id = 2,
                    CreationDate = DateTime.Now,
                    Status = AppStatusType.Submitted
                },
                new JobApplication()
                {
                    Id = 3,
                    CreationDate = DateTime.Now,
                    Status = AppStatusType.Submitted
                }
            };
            context.JobApplications.AddRange(jobApplications);

            var user =
                new ApplicationUser()
                {
                    Id = "TestUser",
                    JobApplications = jobApplications
                };
            context.Users.Add(user);

            var jobPost =
                new JobPost()
                {
                    Id = 1,
                    JobApplications = jobApplications
                };
            context.JobPosts.Add(jobPost);
            context.SaveChanges();
        }



    }
}
