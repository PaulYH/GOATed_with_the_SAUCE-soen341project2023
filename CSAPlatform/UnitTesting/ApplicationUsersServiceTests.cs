using DatabaseAccess.Enums;

namespace UnitTesting
{
    public class ApplicationUsersServiceTests : IDisposable
    {

        private static DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ApplicationUsersServiceTests").Options;

        ApplicationDbContext context;
        ApplicationUserService userService;

        public ApplicationUsersServiceTests()
        {
            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            userService = new ApplicationUserService(context);

            SeedDatabase();
        }


        public void Dispose()
        {
            context.Database.EnsureDeleted();

        }

        [Fact]
        public void Test_GetUserById()
        {
            String test_User_String = "testUser1";
            ApplicationUser expected_user = context.Users.First();
            //Act

            
            ApplicationUser test_user = userService.GetUserById(test_User_String);

            //Assert

            Assert.Equal(test_User_String, test_user.Id);

        }

        [Fact]
        public void Test_UpdateUser()
        {
            String test_User_String = "testUser1";
            ApplicationUser updated_User = context.Users.First();
            updated_User.PhoneNumber = "5144355654";

            userService.UpdateUser(updated_User);

            Assert.Equal("5144355654", context.Users.First().PhoneNumber);

        }

        [Fact]
        public void Test_UploadPdf()
        {
            byte[] temp_file = {4,34,11};

            ApplicationUser appUser = userService.UploadPdf("testUser1", temp_file);

            Assert.Equal(temp_file, appUser.Attachment);
        }

        [Fact]
        public async Task Test_DeletePdf()
        {
            byte[] temp_file = { 4, 34, 11 };

            userService.UploadPdf("testUser1", temp_file);
            userService.DeletePdf("testUser1");

            Assert.Equal(null, context.Users.First().Attachment);

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