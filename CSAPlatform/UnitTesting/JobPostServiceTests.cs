using DatabaseAccess.Enums;

namespace UnitTesting
{
    public class JobPostServiceTests : IDisposable
    {
        private static DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "JobPostServiceTests").Options;

        ApplicationDbContext context;
        JobPostService service;

        public JobPostServiceTests()
        {
            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            service = new JobPostService(context);

            SeedDatabase();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetAllJobPostsTest_ShouldReturnJobPostList_Count4()
        {
            //Arrange
            context.JobPosts.Add(new JobPost() { Id = 4 });
            var count = context.JobPosts.Count();

            //Act
            List<JobPost> posts = await service.GetAllJobPosts();

            //Assert
            Assert.Equal(count, posts.Count());
        }

        [Fact]
        public async Task GetUserJobPostsTest_ShouldReturnJobPostList_Count3()
        {
            //Arrange
            var count = context.JobPosts.Count();

            //Act
            List<JobPost> posts = await service.GetUserJobPosts("testUser1");

            //Assert
            Assert.Equal(count, posts.Count);
        }

        [Fact]
        public async Task GetJobPostByIdTest_ShouldReturnJobPost_MatchingTitle()
        {
            //Arrange
            var id = 1;

            //Act
            JobPost selectedPost = await service.GetJobPostById(id);

            //Assert
            Assert.Equal("Job Title 1", selectedPost.JobTitle);
        }

        [Fact]
        public void CreateJobTest_ShouldIncrementCountAndReturnString()
        {
            //Arrange
            var count = context.JobPosts.Count();
            var expectedMessage = "New Job created successfully";

            //Act
            var returnedMessage = service.CreateJob(new JobPost() { Id = count + 1 });

            //Assert
            Assert.Equal(count + 1, context.JobPosts.Count());
            Assert.Equal(expectedMessage, returnedMessage);
        }

        [Fact]
        public void UpdateJobTest_ShouldChangePropertyAndReturnString()
        {
            //Arrange
            var newTitle = "New Job Title";
            var expectedMessage = "Job post updated successfully";

            JobPost jobPost = context.JobPosts.First();
            jobPost.JobTitle = newTitle;

            //Act
            var returnedMessage = service.UpdateJob(jobPost);

            //Assert
            Assert.Equal(newTitle, context.JobPosts.First().JobTitle);
            Assert.Equal(expectedMessage, returnedMessage);
        }

        [Fact]
        public void DeleteJobTest_ShouldDecrementCountAndReturnString()
        {
            //Arrange
            var count = context.JobPosts.Count();
            var expectedMessage = "Job post has been deleted";

            //Act
            var returnedMessage = service.DeleteJob(context.JobPosts.First());

            //Assert
            Assert.Equal(count - 1, context.JobPosts.Count());
            Assert.Equal(expectedMessage, returnedMessage);
        }

        private void SeedDatabase()
        {
            var jobPosts = new List<JobPost>()
            {
                new JobPost()
                {
                    Id = 1,
                    JobTitle = "Job Title 1",
                    CreationDate = DateTime.Now,
                    ExpirationDate = new DateTime(2023,10,4),
                    JobType = JobType.Onsite,
                    Salary = new decimal(23.21)
                },
                new JobPost()
                {
                    Id = 2,
                    JobTitle = "Job Title 2",
                    CreationDate = DateTime.Now,
                    ExpirationDate = new DateTime(2023,11,21),
                    JobType = JobType.Remote,
                    Salary = new decimal(71.32)
                },
                new JobPost()
                {
                    Id = 3,
                    JobTitle = "Job Title 3",
                    CreationDate = DateTime.Now,
                    ExpirationDate = new DateTime(2023,9,2),
                    JobType = JobType.Hybrid,
                    Salary = new decimal(13.22)
                }
            };
            context.JobPosts.AddRange(jobPosts);

            var employer1 = 
                new ApplicationUser()
                {
                    Id = "testUser1",
                    JobPosts = jobPosts
                };
            context.Users.Add(employer1);

            context.SaveChanges();
        }
    }
}